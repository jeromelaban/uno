#nullable enable

using System;
using System.Runtime.InteropServices;
using Cairo;
using Gdk;
using Gtk;
using LibVLCSharp.Shared;
using Uno.Extensions;
using Uno.Logging;

namespace LibVLCSharp.GTK
{
	/// <summary>
	/// GTK VideoView for Windows, Linux and Mac.
	/// Mac is currently unsupported (see https://github.com/mono/gtk-sharp/issues/257)
	/// </summary>
	public class VideoView : DrawingArea, IVideoView
	{
		struct Native
		{
			[DllImport("libgdk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr gdk_win32_window_get_handle(IntPtr window);

			/// <summary>
			/// Gets the window's HWND
			/// </summary>
			/// <remarks>Window only</remarks>
			/// <param name="gdkWindow">The pointer to the GdkWindow object</param>
			/// <returns>The window's HWND</returns>
			[DllImport("libgdk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr gdk_win32_drawable_get_handle(IntPtr gdkWindow);

			/// <summary>
			/// Gets the window's X11 ID
			/// </summary>
			[DllImport("libgdk-3.so.0", CallingConvention = CallingConvention.Cdecl)]
			internal static extern uint gdk_x11_window_get_xid(IntPtr gdkWindow);

			/// <summary>
			/// Gets the nsview's handle
			/// </summary>
			/// <remarks>Mac only</remarks>
			/// <param name="gdkWindow">The pointer to the GdkWindow object</param>
			/// <returns>The nsview's handle</returns>
			[DllImport("libgdk-3.0.dylib", CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr gdk_quartz_window_get_nsview(IntPtr gdkWindow);

			/// <summary>
			/// Initializes X11 threads support, as required by LibVLCSharp.
			/// </summary>
			[DllImport("libX11.so")]
			internal static extern int XInitThreads();
		}

		private MediaPlayer? _mediaPlayer;
		private Gdk.Window? _videoWindow;

		/// <summary>
		/// GTK VideoView constructor
		/// </summary>
		public VideoView()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			{
				Native.XInitThreads();
			}

			Core.Initialize();

			//            Color black = Color.Zero;
			//#pragma warning disable CS0612 // Type or member is obsolete
			//            Color.Parse("black", ref black);
			//            ModifyBg(StateType.Normal, black);
			//#pragma warning restore CS0612 // Type or member is obsolete

			Realized += (s, e) => Attach();
		}

		/// <summary>
		/// The MediaPlayer property for that GTK VideoView
		/// </summary>
		public MediaPlayer? MediaPlayer
		{
			get => _mediaPlayer;
			set
			{
				if (ReferenceEquals(_mediaPlayer, value))
				{
					return;
				}

				Detach();
				_mediaPlayer = value;
				Attach();
			}
		}

		internal Size NaturalVideoSize { get; set; }

		internal Size ActualSize { get; set; }

		//protected override void OnAdjustSizeAllocation(Orientation orientation, out int minimum_size, out int natural_size, out int allocated_pos, out int allocated_size)
		//{
		//	base.OnAdjustSizeAllocation(orientation, out minimum_size, out natural_size, out allocated_pos, out allocated_size);

		//	Console.WriteLine($"VideoView OnAdjustSizeAllocation {orientation} {minimum_size} {natural_size} {allocated_pos} {allocated_size}");
		//}

		//protected override void OnAdjustSizeRequest(Orientation orientation, out int minimum_size, out int natural_size)
		//{
		//	base.OnAdjustSizeRequest(orientation, out minimum_size, out natural_size);

		//	//if (orientation == Orientation.Horizontal)
		//	//{
		//	//	natural_size = NaturalVideoSize.Width;
		//	//}
		//	//else
		//	//{
		//	//	natural_size = NaturalVideoSize.Height;
		//	//}

		//	Console.WriteLine($"VideoView OnAdjustSizeRequest {orientation} {minimum_size} {natural_size}");
		//}

		private void Attach()
		{
			if (!IsRealized || _mediaPlayer == null)
			{
				return;
			}

			// Create a new Gdk.Window with the specified attributes
			var attr = new WindowAttr
			{
				WindowType = Gdk.WindowType.Child,
				X = 0,
				Y = 0,
				Width = 0,
				Height = 0,
				Wclass = WindowWindowClass.InputOutput,
				Visual = Screen.Default.RgbaVisual,
				EventMask = (int)EventMask.ExposureMask
			};

			var attrs_mask = WindowAttributesType.X | WindowAttributesType.Y | WindowAttributesType.Visual;

			// Create the child window
			_videoWindow = new Gdk.Window(Window.Toplevel, attr, attrs_mask);
			_videoWindow.SkipTaskbarHint = true;
			_videoWindow.SkipPagerHint = true;

			_videoWindow.Show();

			if (this.Log().IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
			{
				this.Log().Debug("Attaching player");
			}

			if (PlatformHelper.IsWindows)
			{
				_mediaPlayer.Hwnd = Native.gdk_win32_window_get_handle(_videoWindow.Handle);
			}
			else if (PlatformHelper.IsLinux)
			{
				var xid = Native.gdk_x11_window_get_xid(this.Window.Handle);

				if (xid != 0)
				{
					_mediaPlayer.XWindow = xid;
				}
				else
				{
					if (this.Log().IsEnabled(Microsoft.Extensions.Logging.LogLevel.Error))
					{
						this.Log().Error("Unable to get the X11 Window ID. This may be caused when running in a Wayland environment, such as WSLg.");
					}

					_mediaPlayer.Stop();
				}
			}
			else if (PlatformHelper.IsMac)
			{
				_mediaPlayer.NsObject = Native.gdk_quartz_window_get_nsview(this.Window.Handle);
			}
			else
			{
				throw new PlatformNotSupportedException();
			}

		}

		void Detach()
		{
			if (!IsRealized || _mediaPlayer == null)
			{
				return;
			}

			if (PlatformHelper.IsWindows)
			{
				_mediaPlayer.Hwnd = IntPtr.Zero;
			}
			else if (PlatformHelper.IsLinux)
			{
				_mediaPlayer.XWindow = 0;
			}
			else if (PlatformHelper.IsMac)
			{
				_mediaPlayer.NsObject = IntPtr.Zero;
			}
			else
			{
				throw new PlatformNotSupportedException();
			}
		}

		internal void Arrange(Gdk.Rectangle value)
		{
			_videoWindow?.MoveResize(value.X, value.Y, value.Width, value.Height);
			Console.WriteLine($"VideoView ArrangeWindow: {value.X}x{value.Y} / {value.Width}x{value.Height}");
		}
	}
}
