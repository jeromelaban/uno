#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SkiaSharp;
using Uno.UI.Skia.Platform;
using Windows.Graphics.Display;
using WinUI = Windows.UI.Xaml;

namespace Uno.UI.Runtime.Skia.Wpf
{
	internal class SoftwareRenderSurface : Border, IRenderSurface
	{
		private readonly bool designMode;
		private readonly WpfHost _host;
		private readonly DisplayInformation _displayInformation;

		private WriteableBitmap? bitmap;

		public SoftwareRenderSurface(WpfHost host)
		{
			_host = host;
			_displayInformation = DisplayInformation.GetForCurrentView();

			designMode = DesignerProperties.GetIsInDesignMode(this);
		}

		public void Refresh() => InvalidateVisual();

		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);

			if (designMode)
			{
				return;
			}

			if (ActualWidth == 0
				|| ActualHeight == 0
				|| double.IsNaN(ActualWidth)
				|| double.IsNaN(ActualHeight)
				|| double.IsInfinity(ActualWidth)
				|| double.IsInfinity(ActualHeight)
				|| _host.Visibility != Visibility.Visible)
			{
				return;
			}


			int width, height;


			var dpi = _displayInformation.RawPixelsPerViewPixel;
			double dpiScaleX = dpi;
			double dpiScaleY = dpi;
			if (_host.IgnorePixelScaling)
			{
				width = (int)ActualWidth;
				height = (int)ActualHeight;
			}
			else
			{
				var matrix = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
				dpiScaleX = matrix.M11;
				dpiScaleY = matrix.M22;
				width = (int)(ActualWidth * dpiScaleX);
				height = (int)(ActualHeight * dpiScaleY);
			}

			var info = new SKImageInfo(width, height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

			// reset the bitmap if the size has changed
			if (bitmap == null || info.Width != bitmap.PixelWidth || info.Height != bitmap.PixelHeight)
			{
				bitmap = new WriteableBitmap(width, height, 96 * dpiScaleX, 96 * dpiScaleY, PixelFormats.Pbgra32, null);
			}

			// draw on the bitmap
			bitmap.Lock();
			using (var surface = SKSurface.Create(info, bitmap.BackBuffer, bitmap.BackBufferStride))
			{
				surface.Canvas.Clear(SKColors.White);
				surface.Canvas.SetMatrix(SKMatrix.CreateScale((float)dpiScaleX, (float)dpiScaleY));
				WinUI.Window.Current.Compositor.Render(surface);
			}

			// draw the bitmap to the screen
			bitmap.AddDirtyRect(new Int32Rect(0, 0, width, height));
			bitmap.Unlock();
			drawingContext.DrawImage(bitmap, new Rect(0, 0, ActualWidth, ActualHeight));
		}

	}
}
