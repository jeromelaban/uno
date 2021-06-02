#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.Extensions.Logging;
using Uno.Extensions;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;
using Uno.UI.Runtime.Skia.Native;
using static Uno.UI.Runtime.Skia.Native.LibInput;
using static Windows.UI.Input.PointerUpdateKind;
using static Uno.UI.Runtime.Skia.Native.libinput_event_type;
using Uno.Logging;
using System.Runtime.CompilerServices;

namespace Uno.UI.Runtime.Skia
{
	unsafe internal partial class CoreWindowExtension : ICoreWindowExtension, IDisposable
	{
		private readonly CoreWindow _owner;
		private readonly ICoreWindowEvents _ownerEvents;
		private readonly IntPtr _libInputContext;
		private readonly Dictionary<uint, Point> _activePointers = new Dictionary<uint, Point>();
		private readonly HashSet<libinput_event_code> _pointerPressed = new HashSet<libinput_event_code>();
		private readonly DisplayInformation _displayInformation;
		private readonly Thread _inputThread;
		private Point _mousePosition;
		private int _libDevFd;
		private readonly CancellationTokenSource _cts = new CancellationTokenSource();

		public CoreWindowExtension(object owner)
		{
			_owner = (CoreWindow)owner;
			_ownerEvents = (ICoreWindowEvents)owner;
			_displayInformation = DisplayInformation.GetForCurrentView();

			try
			{
				_libInputContext = libinput_path_create_context();

				_inputThread = new Thread(Run)
				{
					Name = "Uno libdev Input",
					IsBackground = true
				};

				_inputThread.Start();
			}
			catch (Exception ex)
			{
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().LogWarning($"Failed to initialize LibInput, continuing without pointer and keyboard support ({ex.Message})");
				}
			}
		}

		private void Run()
		{
			_libDevFd = libinput_get_fd(_libInputContext);

			var timeval = stackalloc IntPtr[2];

			foreach (var f in Directory.GetFiles("/dev/input", "event*"))
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Opening input device {f}");
				}

				var device = libinput_path_add_device(_libInputContext, f);

				if (device != IntPtr.Zero)
				{
					if (libinput_device_config_calibration_has_matrix(device) != 0)
					{
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Device {f} supports calibration");
						}

						var matrix = new float[6];
						Console.WriteLine("before libinput_device_config_calibration_get_matrix");
						var result = libinput_device_config_calibration_get_matrix(device, matrix);
						Console.WriteLine("after libinput_device_config_calibration_get_matrix");

						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							var formattedMatrix = GetFormattedMatrix(matrix);
							this.Log().Debug($"Current Device {f} current matrix: {formattedMatrix} result2: {result}");
						}

						var defaultMatrix = new float[6];
						var result2 = libinput_device_config_calibration_get_default_matrix(device, defaultMatrix);

						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							var formattedMatrix = GetFormattedMatrix(matrix);
							this.Log().Debug($"Current Device {f} default matrix: {formattedMatrix} result2: {result2}");
						}

						var result3 = libinput_device_config_calibration_set_matrix(device, defaultMatrix);

						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							var formattedMatrix = GetFormattedMatrix(matrix);
							this.Log().Debug($"Current Device {f} Applied default matrix, result:{result3}");
						}
					}
					else
					{
						if (this.Log().IsEnabled(LogLevel.Debug))
						{
							this.Log().Debug($"Device {f} does not support calibration");
						}
					}
				}


			}

			while (!_cts.IsCancellationRequested)
			{
				IntPtr rawEvent;
				libinput_dispatch(_libInputContext);
				while ((rawEvent = libinput_get_event(_libInputContext)) != IntPtr.Zero)
				{
					var type = libinput_event_get_type(rawEvent);

					if (this.Log().IsEnabled(LogLevel.Trace))
					{
						this.Log().Trace($"Got event type (0x{rawEvent:X16}) {type}");
					}

					if (type >= LIBINPUT_EVENT_TOUCH_DOWN
						&& type <= LIBINPUT_EVENT_TOUCH_CANCEL)
					{
						ProcessTouchEvent(rawEvent, type);
					}

					if (type >= LIBINPUT_EVENT_POINTER_MOTION
						&& type <= LIBINPUT_EVENT_POINTER_AXIS)
					{
						ProcessMouseEvent(rawEvent, type);
					}

					if (type == LIBINPUT_EVENT_KEYBOARD_KEY)
					{
						ProcessKeyboardEvent(rawEvent, type);
					}

					libinput_event_destroy(rawEvent);
					libinput_dispatch(_libInputContext);
				}

				var pfd = new pollfd { fd = _libDevFd, events = 1 };
				Libc.poll(&pfd, (IntPtr)1, -1);
			}
		}

		private static string GetFormattedMatrix(float[] matrix)
			=> $"{matrix[0]} {matrix[1]} {matrix[2]} {matrix[3]} {matrix[4]} {matrix[5]}";

		private void RaisePointerEvent(Action<PointerEventArgs> raisePointerEvent, PointerEventArgs args)
		{
			_owner.Dispatcher.RunAsync(
				CoreDispatcherPriority.High,
				() => raisePointerEvent(args));
		}

		public CoreCursor PointerCursor { get => new CoreCursor(CoreCursorType.Arrow, 0); set { } }

		public void ReleasePointerCapture() { }

		public void SetPointerCapture() { }

		public void Dispose()
		{
			if (_libDevFd != 0)
			{
				Libc.close(_libDevFd);
				_libDevFd = 0;

				_cts.Cancel();
			}
		}
	}
}
