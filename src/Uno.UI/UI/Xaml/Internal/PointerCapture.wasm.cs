#nullable enable

using System;
using System.Linq;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;

namespace Uno.UI.Xaml.Core;

internal partial class PointerCapture
{
	partial void CaptureNative(UIElement target, Pointer pointer)
		=> WindowManagerInterop.SetPointerCapture(target.HtmlId, pointer.PointerId);

	partial void ReleaseNative(UIElement target, Pointer pointer)
		=> WindowManagerInterop.ReleasePointerCapture(target.HtmlId, pointer.PointerId);
}
