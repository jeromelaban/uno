using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Popups;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Media;
using static Private.Infrastructure.TestServices;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Popups
{
	[TestClass]
	public class Given_MessageDialog
	{
#if !__WASM__
#if __SKIA__
		[Ignore("https://github.com/unoplatform/uno/issues/7271")]
#endif
		[TestMethod]
		[RunsOnUIThread]
		public async Task Should_Close_Open_Popups()
		{
			var button = new Microsoft.UI.Xaml.Controls.Button();
			var flyout = new Flyout();
			FlyoutBase.SetAttachedFlyout(button, flyout);
			WindowHelper.WindowContent = button;
			Assert.AreEqual(0, VisualTreeHelper.GetOpenPopups(Window.Current).Count);
			FlyoutBase.ShowAttachedFlyout(button);
			Assert.AreEqual(1, VisualTreeHelper.GetOpenPopups(Window.Current).Count);
			var messageDialog = new MessageDialog("Hello");
			var asyncOperation = messageDialog.ShowAsync();
			Assert.AreEqual(0, VisualTreeHelper.GetOpenPopups(Window.Current).Count);
			asyncOperation.Cancel();
		}
#endif
	}
}
