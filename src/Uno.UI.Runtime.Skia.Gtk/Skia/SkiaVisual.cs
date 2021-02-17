using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.ApplicationModel;
using Windows.Graphics.Display;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Uno.UI.Runtime.Skia;

namespace Uno.UI.Runtime.Skia
{
	public class SkiaVisual : Visual
	{
		private Action<SKCanvas> _renderer;

		internal SkiaVisual(Compositor compositor, Action<SKCanvas> renderer) : base(compositor)
		{
			_renderer = renderer;
		}

		internal override void Render(SKSurface surface, SKImageInfo info)
		{
			base.Render(surface, info);
		}
	}
}


namespace SkiaSharp.Views.UWP
{
	public partial class SKXamlCanvas : FrameworkElement
	{
		private static bool designMode = DesignMode.DesignModeEnabled;

		private bool ignorePixelScaling;
		private bool isVisible = true;
		private int pixelWidth;
		private int pixelHeight;

		// workaround for https://github.com/mono/SkiaSharp/issues/1118
		private int loadUnloadCounter = 0;

		private void Initialize()
		{
			if (designMode)
				return;

			var display = DisplayInformation.GetForCurrentView();
			OnDpiChanged(display);

			Loaded += OnLoaded;
			Unloaded += OnUnloaded;
			SizeChanged += OnSizeChanged;

			var compositor = ElementCompositionPreview.GetElementChildVisual(this).Compositor;
			ElementCompositionPreview.SetElementChildVisual(this, new SkiaVisual(compositor, ));

			var visual = ElementCompositionPreview.GetElementVisual(this);
			visual.
		}

		public SKSize CanvasSize => GetCanvasSize();

		public bool IgnorePixelScaling
		{
			get => ignorePixelScaling;
			set
			{
				ignorePixelScaling = value;
				Invalidate();
			}
		}

		public double Dpi { get; private set; } = 1;

		public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface;

		protected virtual void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			PaintSurface?.Invoke(this, e);
		}

		private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (d is SKXamlCanvas canvas && e.NewValue is Visibility visibility)
			{
				canvas.isVisible = visibility == Visibility.Visible;
				canvas.Invalidate();
			}
		}

		private void OnDpiChanged(DisplayInformation sender, object args = null)
		{
			Dpi = sender.LogicalDpi / 96.0f;
			Invalidate();
		}

		private void OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			Invalidate();
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			loadUnloadCounter++;
			if (loadUnloadCounter != 1)
				return;

			DoLoaded();

			var display = DisplayInformation.GetForCurrentView();
			display.DpiChanged += OnDpiChanged;

			OnDpiChanged(display);
		}

		private void OnUnloaded(object sender, RoutedEventArgs e)
		{
			loadUnloadCounter--;
			if (loadUnloadCounter != 0)
				return;

			DoUnloaded();

			var display = DisplayInformation.GetForCurrentView();
			display.DpiChanged -= OnDpiChanged;
		}

		public void Invalidate()
		{
			if (Dispatcher.HasThreadAccess)
				DoInvalidate();
			else
				Dispatcher.RunAsync(CoreDispatcherPriority.Normal, DoInvalidate);
		}

		partial void DoLoaded();

		partial void DoUnloaded();

		private SKSize GetCanvasSize() =>
			new SKSize(pixelWidth, pixelHeight);

		private void DoInvalidate()
		{
			if (designMode)
				return;

			if (!isVisible)
				return;

			if (ActualWidth <= 0 || ActualHeight <= 0)
				return;

			int width, height;
			if (IgnorePixelScaling)
			{
				width = (int)ActualWidth;
				height = (int)ActualHeight;
			}
			else
			{
				width = (int)(ActualWidth * Dpi);
				height = (int)(ActualHeight * Dpi);
			}

			pixelWidth = width;
			pixelHeight = height;

			var info = new SKImageInfo(width, height, SKImageInfo.PlatformColorType, SKAlphaType.Opaque);

			OnPaintSurface(new SKPaintSurfaceEventArgs(surface, info));
		}
	}

	public class SKPaintSurfaceEventArgs : EventArgs
	{
		public SKPaintSurfaceEventArgs(SKSurface surface, SKImageInfo info)
		{
			Surface = surface;
			Info = info;
		}

		public SKSurface Surface { get; private set; }

		public SKImageInfo Info { get; private set; }
	}
}
