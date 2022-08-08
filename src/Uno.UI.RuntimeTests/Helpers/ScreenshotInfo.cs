using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Runtime.InteropServices.WindowsRuntime;

using Rectangle = System.Drawing.Rectangle;
using Size = System.Drawing.Size;
using Point = System.Drawing.Point;
using Windows.UI;

namespace Uno.UI.RuntimeTests.Helpers
{

	public class RawBitmap
	{
		private RenderTargetBitmap bitmap;
		private byte[]? _pixels;

		public RawBitmap(RenderTargetBitmap bitmap)
		{
			this.bitmap = bitmap;
		}

		public Size Size => new(bitmap.PixelWidth, bitmap.PixelHeight);

		public int Width => bitmap.PixelWidth;
		public int Height => bitmap.PixelHeight;

		public Color GetPixel(int x, int y)
		{
			if(_pixels is null)
			{
				throw new InvalidOperationException("Populate must be invoked first");
			}

			var offset = (y * Width + x) * 4;
			var a = _pixels[offset + 3];
			var r = _pixels[offset + 2];
			var g = _pixels[offset + 1];
			var b = _pixels[offset + 0];

			return Color.FromArgb(a, r, g, b);
		}
		
		internal async Task Populate()
		{
			_pixels = (await bitmap.GetPixelsAsync()).ToArray();
		}
	}
}
