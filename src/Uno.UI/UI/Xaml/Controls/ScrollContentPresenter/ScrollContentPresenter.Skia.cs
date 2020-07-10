using Uno.Extensions;
using Uno.Logging;
using Uno.UI.DataBinding;
using Windows.UI.Xaml.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Uno.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Foundation;

namespace Windows.UI.Xaml.Controls
{
	public partial class ScrollContentPresenter : ContentPresenter
	{
		public ScrollMode HorizontalScrollMode { get; set; }

		public ScrollMode VerticalScrollMode { get; set; }

		public float MinimumZoomScale { get; set; }

		public float MaximumZoomScale { get; set; }

		public ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

		public ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }

		internal Size ScrollBarSize
		{
			get
			{
				return new Size(0, 0);
			}
		}

		public ScrollContentPresenter()
		{
			PointerWheelChanged += ScrollContentPresenter_PointerWheelChanged;
		}

		private void ScrollContentPresenter_PointerWheelChanged(object sender, Input.PointerRoutedEventArgs e)
		{
			var properties = e.GetCurrentPoint(null).Properties;

			(TemplatedParent as ScrollViewer)?.OnScrollInternal(
				properties.IsHorizontalMouseWheel ? properties.MouseWheelDelta : 0,
				!properties.IsHorizontalMouseWheel ? properties.MouseWheelDelta : 0,
				false
			);
		}
	}
}
