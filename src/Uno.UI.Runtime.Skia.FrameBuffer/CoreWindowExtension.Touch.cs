#nullable enable

using System;
using Microsoft.Extensions.Logging;
using Uno.Extensions;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Input;
using Uno.UI.Runtime.Skia.Native;
using static Uno.UI.Runtime.Skia.Native.LibInput;
using static Windows.UI.Input.PointerUpdateKind;
using static Uno.UI.Runtime.Skia.Native.libinput_event_type;

using Uno.Logging;

namespace Uno.UI.Runtime.Skia
{
	unsafe internal partial class CoreWindowExtension : ICoreWindowExtension
	{
		private void ProcessTouchEvent(IntPtr rawEvent, libinput_event_type rawEventType)
		{
			var rawTouchEvent = libinput_event_get_touch_event(rawEvent);

			if (rawTouchEvent != IntPtr.Zero
				&& rawEventType < LIBINPUT_EVENT_TOUCH_FRAME)
			{
				var properties = new PointerPointProperties();
				var timestamp = libinput_event_pointer_get_time_usec(rawTouchEvent);
				var pointerId = (uint)libinput_event_touch_get_slot(rawTouchEvent);
				Action<PointerEventArgs>? raisePointerEvent = null;
				Point pt;

				if (rawEventType == LIBINPUT_EVENT_TOUCH_DOWN
					|| rawEventType == LIBINPUT_EVENT_TOUCH_MOTION)
				{
					pt = new Point(
						x: libinput_event_touch_get_x_transformed(rawTouchEvent, (int)_displayInformation.ScreenWidthInRawPixels),
						y: libinput_event_touch_get_y_transformed(rawTouchEvent, (int)_displayInformation.ScreenHeightInRawPixels));

					_activePointers[pointerId] = pt;
				}
				else
				{
					_activePointers.TryGetValue(pointerId, out pt);
					_activePointers.Remove(pointerId);
				}

				switch (rawEventType)
				{
					case LIBINPUT_EVENT_TOUCH_DOWN:
						properties.PointerUpdateKind = LeftButtonPressed;
						raisePointerEvent = _ownerEvents.RaisePointerPressed;
						break;

					case LIBINPUT_EVENT_TOUCH_UP:
						properties.PointerUpdateKind = LeftButtonReleased;
						raisePointerEvent = _ownerEvents.RaisePointerReleased;
						break;

					case LIBINPUT_EVENT_TOUCH_CANCEL:
						properties.PointerUpdateKind = LeftButtonReleased;
						raisePointerEvent = _ownerEvents.RaisePointerCancelled;
						break;
				}

				properties.IsLeftButtonPressed = rawEventType != LIBINPUT_EVENT_TOUCH_UP && rawEventType != LIBINPUT_EVENT_TOUCH_CANCEL;

				var pointerPoint = new Windows.UI.Input.PointerPoint(
					frameId: (uint)timestamp, // UNO TODO: How should set the frame, timestamp may overflow.
					timestamp: timestamp,
					device: PointerDevice.For(PointerDeviceType.Touch),
					pointerId: pointerId,
					rawPosition: _mousePosition,
					position: _mousePosition,
					isInContact: properties.HasPressedButton,
					properties: properties
				);

				if (raisePointerEvent != null)
				{
					var args = new PointerEventArgs(pointerPoint, GetCurrentModifiersState());

					RaisePointerEvent(raisePointerEvent, args);
				}
				else
				{
					this.Log().LogWarning($"Touch event type {rawEventType} was not handled");
				}
			}
		}
	}
}
