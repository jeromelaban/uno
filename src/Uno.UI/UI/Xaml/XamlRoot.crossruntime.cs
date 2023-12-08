﻿using System;
using Uno.Foundation.Logging;
using Uno.UI.Dispatching;

namespace Microsoft.UI.Xaml;

public sealed partial class XamlRoot
{
	private bool _renderQueued;

	internal event Action InvalidateRender = () => { };

	internal void InvalidateMeasure() => VisualTree.RootElement.InvalidateMeasure();

	internal void InvalidateArrange() => VisualTree.RootElement.InvalidateArrange();

	internal void RaiseInvalidateRender()
	{
		InvalidateRender();
	}

	internal void QueueInvalidateRender()
	{
		if (!_renderQueued)
		{
			_renderQueued = true;

			DispatchQueueRender();
		}
	}

	private void DispatchQueueRender()
	{
		NativeDispatcher.Main.Enqueue(() =>
		{
			if (_renderQueued)
			{
				_renderQueued = false;
				InvalidateRender();
			}
		});
	}

	/// <summary>
	/// This is used to adjust the sizing of managed vs. native elements on GTK, as it does not have built-in support for fractional scaling
	/// which is available on Windows. We can still emulate this by up-scaling native GTK controls by the ratio between the actual scale 
	/// and the emulated scale.
	/// </summary>
	internal double FractionalScaleAdjustment => RasterizationScale / Math.Truncate(RasterizationScale);
}
