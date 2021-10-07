#nullable enable

using Windows.Foundation;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Microsoft.UI.Xaml
{
	public partial class DragUI 
	{
		internal ImageSource? Content { get; set; }

		internal Point? Anchor { get; private set; }

		public void SetContentFromBitmapImage(BitmapImage bitmapImage)
		{
			Content = bitmapImage;
		}

		public void SetContentFromBitmapImage(BitmapImage bitmapImage, Point anchorPoint)
		{
			Content = bitmapImage;
			Anchor = anchorPoint;
		}
	}
}
