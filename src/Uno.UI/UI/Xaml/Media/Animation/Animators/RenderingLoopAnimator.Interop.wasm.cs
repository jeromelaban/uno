﻿#if NET7_0_OR_GREATER
using System;
using System.Runtime.InteropServices.JavaScript;

namespace __Microsoft.UI.Xaml.Media.Animation
{
	internal partial class RenderingLoopAnimator
	{
		internal static partial class NativeMethods
		{
			[JSImport("globalThis.Microsoft.UI.Xaml.Media.Animation.RenderingLoopAnimator.createInstance")]
			internal static partial void CreateInstance(IntPtr managedHandle, double id);

			[JSImport("globalThis.Microsoft.UI.Xaml.Media.Animation.RenderingLoopAnimator.destroyInstance")]
			internal static partial void DestroyInstance(double jsHandle);
		}
	}
}
#endif
