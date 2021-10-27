#if UNO_HAS_MANAGED_POINTERS
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Windows.Devices.Input;
using Uno;
using Windows.Foundation;
using Windows.UI.Xaml.Media;
using Windows.UI.Core;

#if HAS_UNO_WINUI
using Microsoft.UI.Input;
#else
using Windows.UI.Input;
#endif

namespace Windows.UI.Xaml.Input
{
	partial class PointerRoutedEventArgs
	{
		private readonly PointerEventArgs _pointerEventArgs;

		internal PointerRoutedEventArgs(
			PointerEventArgs pointerEventArgs,
			UIElement source) : this()
		{
			_pointerEventArgs = pointerEventArgs;

			FrameId = pointerEventArgs.CurrentPoint.FrameId;
			Pointer = GetPointer(pointerEventArgs);
			KeyModifiers = pointerEventArgs.KeyModifiers;
			OriginalSource = source;
		}

		public PointerPoint GetCurrentPoint(UIElement relativeTo)
		{
			if (relativeTo is null)
			{
				return null; // _pointerEventArgs.CurrentPoint;
			}
			else
			{
				var absolutePosition = _pointerEventArgs.CurrentPoint.Position;
				var relativePosition = relativeTo.TransformToVisual(null).Inverse.TransformPoint(absolutePosition);

				return null;// _pointerEventArgs.CurrentPoint.At(relativePosition);
			}
		}

		private Pointer GetPointer(PointerEventArgs args)
			=> new Pointer(
				args.CurrentPoint.PointerId,
				args.CurrentPoint.PointerDevice.PointerDeviceType,
				isInContact: args.CurrentPoint.IsInContact,
				isInRange: args.CurrentPoint.Properties.IsInRange);
	}
}
#endif
