using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Uno.UI;
using Uno.UI.Extensions;

namespace Uno.UI.RuntimeTests.Tests.HotReload.Frame
{
	public static class FrameExtensions
	{
		public static async Task ValidateFirstTextBlockOnCurrentPageText(this Windows.UI.Xaml.Controls.Frame frame, string expectedText)
			=> await frame.ValidateTextBlockOnCurrentPageText(expectedText);

		public static async Task ValidateTextBlockOnCurrentPageText(this Windows.UI.Xaml.Controls.Frame frame, string expectedText, int index = 0)
		{
			var page = frame.Content as Page;
			Assert.IsNotNull(page);

			await UnitTestsUIContentHelper.WaitForLoaded(page);

			var firstText = page
				.EnumerateDescendants()
				.OfType<TextBlock>()
				.Skip(index)
				.FirstOrDefault();

			Assert.AreEqual(expectedText, firstText?.Text);
		}

		public static async Task ValidateElementOnCurrentPageText<TElement>(this Windows.UI.Xaml.Controls.Frame frame, Action<TElement> validation, int index = 0)
			where TElement : FrameworkElement
		{
			var page = frame.Content as Page;
			Assert.IsNotNull(page);

			await UnitTestsUIContentHelper.WaitForLoaded(page);

			var firstText = page
				.EnumerateDescendants()
				.OfType<TElement>()
				.Skip(index)
				.FirstOrDefault();

			Assert.IsNotNull(firstText);
			validation(firstText);
		}
	}
}
