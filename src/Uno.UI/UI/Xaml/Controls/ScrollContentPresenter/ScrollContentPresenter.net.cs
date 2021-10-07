using Uno.Extensions;
using Uno.Logging;
using Uno.UI.DataBinding;
using Microsoft.UI.Xaml.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using Uno.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.Foundation;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class ScrollContentPresenter : ContentPresenter, IScrollContentPresenter
	{
		public bool CanHorizontallyScroll { get; set; }
		public bool CanVerticallyScroll { get; set; }

		Size? IScrollContentPresenter.CustomContentExtent => null;

		void IScrollContentPresenter.OnMinZoomFactorChanged(float newValue) { }

		void IScrollContentPresenter.OnMaxZoomFactorChanged(float newValue) { }

		ScrollBarVisibility IScrollContentPresenter.VerticalScrollBarVisibility { get => VerticalScrollBarVisibility; set => VerticalScrollBarVisibility = value; }
		internal ScrollBarVisibility VerticalScrollBarVisibility { get; set; }

		ScrollBarVisibility IScrollContentPresenter.HorizontalScrollBarVisibility { get => HorizontalScrollBarVisibility; set => HorizontalScrollBarVisibility = value; }
		internal ScrollBarVisibility HorizontalScrollBarVisibility { get; set; }
	}
}
