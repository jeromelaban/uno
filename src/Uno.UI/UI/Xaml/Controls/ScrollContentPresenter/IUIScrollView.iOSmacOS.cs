using System;
using System.Collections.Generic;
using System.Text;
using CoreGraphics;

namespace Microsoft.UI.Xaml.Controls
{
	internal interface IUIScrollView
	{
		CGPoint UpperScrollLimit { get; }

		void SetContentOffset(CGPoint contentOffset, bool animated);

#if __IOS__
		void SetZoomScale(nfloat scale, bool animated);
#endif
	}
}
