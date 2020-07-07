using System;
using System.Globalization;
using Uno.Diagnostics.Eventing;
using Uno.Extensions;
using Uno.Logging;
using Windows.Foundation;
using Microsoft.Extensions.Logging;
using Uno.UI;
using static System.Math;
using static Uno.UI.LayoutHelper;
using Windows.UI.Xaml.Media;
using Uno.UI.Extensions;

namespace Windows.UI.Xaml
{
	public partial class FrameworkElement
	{
		internal sealed override Size MeasureCore(Size availableSize)
		{
			if (_trace.IsEnabled)
			{
				var traceActivity = _trace.WriteEventActivity(
					TraceProvider.FrameworkElement_MeasureStart,
					TraceProvider.FrameworkElement_MeasureStop,
					new object[] { GetType().Name, this.GetDependencyObjectId(), Name, availableSize.ToString() }
				);

				using (traceActivity)
				{
					return InnerMeasureCore(availableSize);
				}
			}
			else
			{
				// This method is split in two functions to avoid the dynCalls
				// invocations generation for mono-wasm AOT inside of try/catch/finally blocks.
				return InnerMeasureCore(availableSize);
			}
		}

		private Size InnerMeasureCore(Size availableSize)
		{
			var (minSize, maxSize) = this.GetMinMax();
			var marginSize = this.GetMarginSize();

			var frameworkAvailableSize = availableSize
				.Subtract(marginSize)
				.AtLeast(new Size(0, 0))
				.AtMost(maxSize)
				.AtLeast(minSize);

			var desiredSize = MeasureOverride(frameworkAvailableSize);

			if (_log.IsEnabled(LogLevel.Trace))
			{
				_log.LogTrace($"{this}.MeasureOverride(availableSize={frameworkAvailableSize}): desiredSize={desiredSize}");
			}

			if (
				double.IsNaN(desiredSize.Width)
				|| double.IsNaN(desiredSize.Height)
				|| double.IsInfinity(desiredSize.Width)
				|| double.IsInfinity(desiredSize.Height)
			)
			{
				throw new InvalidOperationException($"{this}: Invalid measured size {desiredSize}. NaN or Infinity are invalid desired size.");
			}

			desiredSize = desiredSize.AtLeast(minSize);

			_unclippedDesiredSize = desiredSize;

			desiredSize = desiredSize.AtMost(maxSize);

			var clippedDesiredSize = desiredSize
				.Add(marginSize)
				.AtMost(availableSize);

			var retSize = clippedDesiredSize.AtLeast(new Size(0, 0));

			if (_log.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
			{
				_log.DebugFormat(
					$"[{this}] Measure({Name}/{availableSize}/{Margin}) = {retSize}"
				);
			}

			return retSize;
		}

		internal sealed override void ArrangeCore(Rect finalRect)
		{
			if (_trace.IsEnabled)
			{
				var traceActivity = _trace.WriteEventActivity(
					TraceProvider.FrameworkElement_ArrangeStart,
					TraceProvider.FrameworkElement_ArrangeStop,
					new object[] { GetType().Name, this.GetDependencyObjectId(), Name, finalRect.ToString() }
				);

				using (traceActivity)
				{
					InnerArrangeCore(finalRect);
				}
			}
			else
			{
				// This method is split in two functions to avoid the dynCalls
				// invocations generation for mono-wasm AOT inside of try/catch/finally blocks.
				InnerArrangeCore(finalRect);
			}
		}

		private void InnerArrangeCore(Rect finalRect)
		{
			var arrangeSize = finalRect.Size;

			var (minSize, maxSize) = this.GetMinMax();
			var marginSize = this.GetMarginSize();

			arrangeSize = arrangeSize
				.Subtract(marginSize)
				.AtLeast(new Size(0, 0));

			arrangeSize = arrangeSize.AtLeast(_unclippedDesiredSize);

			if (HorizontalAlignment != HorizontalAlignment.Stretch)
			{
				arrangeSize.Width = _unclippedDesiredSize.Width;
			}

			if (VerticalAlignment != VerticalAlignment.Stretch)
			{
				arrangeSize.Height = _unclippedDesiredSize.Height;
			}

			var effectiveMaxSize = Max(_unclippedDesiredSize, maxSize);
			arrangeSize = arrangeSize.AtMost(effectiveMaxSize);

			var oldRenderSize = RenderSize;
			var innerInkSize = ArrangeOverride(arrangeSize);

			RenderSize = innerInkSize;

			var clippedInkSize = innerInkSize.AtMost(maxSize);

			var clientSize = finalRect.Size
				.Subtract(marginSize)
				.AtLeast(new Size(0, 0));

			var (offset, overflow) = this.GetAlignmentOffset(clientSize, clippedInkSize);
			offset = new Point(
				offset.X + finalRect.X + Margin.Left,
				offset.Y + finalRect.Y + Margin.Top
			);

			LayoutSlotWithMarginsAndAlignments = new Rect(offset, RenderSize);

			ArrangeVisual(offset, RenderSize);

			if (_log.IsEnabled(Microsoft.Extensions.Logging.LogLevel.Debug))
			{
				_log.Debug(
					$"[{this}] ArrangeChild(offset={offset}, margin={Margin}) [oldRenderSize={oldRenderSize}]"
				);
			}

			OnLayoutUpdated();
		}

		private protected virtual Thickness GetThicknessAdjust() => Thickness.Empty;
	}
}
