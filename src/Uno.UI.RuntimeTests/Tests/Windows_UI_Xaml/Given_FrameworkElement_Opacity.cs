#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using FluentAssertions;
using FluentAssertions.Execution;
using Private.Infrastructure;
using MUXControlsTestApp.Utilities;
using Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.InteropServices.WindowsRuntime;
using SamplesApp.UITests.TestFramework;
using Uno.UI.RuntimeTests.Helpers;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml_Controls
{
	[TestClass]
	public class Given_FrameworkElement_Opacity
	{
		[TestMethod]
		public async Task MyTestMethod()
		{
			var SUT = new FrameworkElement_Opacity();

			TestServices.WindowHelper.WindowContent = SUT;

			await TestServices.WindowHelper.WaitForIdle();

			//Ensure Layouted
			await TestServices.WindowHelper.WaitForIdle();

			var renderer = new RenderTargetBitmap();

			await renderer.RenderAsync(SUT);

			var si = new RawBitmap(renderer);
			await si.Populate();

			var width = SUT.tbOpacity1_0.ActualWidth;
			var height = SUT.tbOpacity1_0.ActualHeight;

			var point = SUT.tbOpacity1_0.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.Black);

			width = SUT.tbOpacity0_5.ActualWidth;
			height = SUT.tbOpacity0_5.ActualHeight;
			point = SUT.tbOpacity0_5.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0x80, 0x80, 0x80));

			width = SUT.tbOpacity0_1.ActualWidth;
			height = SUT.tbOpacity0_1.ActualHeight;
			point = SUT.tbOpacity0_1.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xE6, 0xE6, 0xE6));

			width = SUT.border0_5.ActualWidth;
			height = SUT.border0_5.ActualHeight;
			point = SUT.border0_5.TransformToVisual(SUT).TransformPoint(new Point(2, 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xFF, 0x80, 0x80));

			width = SUT.ImageOpacity0_5.ActualWidth;
			height = SUT.ImageOpacity0_5.ActualHeight;
			point = SUT.ImageOpacity0_5.TransformToVisual(SUT).TransformPoint(new Point(width / 2, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xFE, 0xF3, 0xC2));

			//
			// Inner
			//
			width = SUT.tbInnerOpacity1_0.ActualWidth;
			height = SUT.tbInnerOpacity1_0.ActualHeight;
			point = SUT.tbInnerOpacity1_0.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3.3, height / 2));	
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0x80, 0x80, 0x80));

			width = SUT.tbInnerOpacity0_5.ActualWidth;
			height = SUT.tbInnerOpacity0_5.ActualHeight;
			point = SUT.tbInnerOpacity0_5.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3.3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xC0, 0xC0, 0xC0));

			width = SUT.tbInnerOpacity0_1.ActualWidth;
			height = SUT.tbInnerOpacity0_1.ActualHeight;
			point = SUT.tbInnerOpacity0_1.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3.3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xF3, 0xF3, 0xF3));

			width = SUT.BorderInnerOpacity0_5.ActualWidth;
			height = SUT.BorderInnerOpacity0_5.ActualHeight;
			point = SUT.BorderInnerOpacity0_5.TransformToVisual(SUT).TransformPoint(new Point(2, 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xFF, 0xC0, 0xC0));

			width = SUT.tbBorderInnerOpacity0_5.ActualWidth;
			height = SUT.tbBorderInnerOpacity0_5.ActualHeight;
			point = SUT.tbBorderInnerOpacity0_5.TransformToVisual(SUT).TransformPoint(new Point((width / 4) * 3.3, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xC0, 0x90, 0x90));

			width = SUT.ImageInner0_5.ActualWidth;
			height = SUT.ImageInner0_5.ActualHeight;
			point = SUT.ImageInner0_5.TransformToVisual(SUT).TransformPoint(new Point(width / 2, height / 2));
			ImageAssert.HasColorAt(si, (float)point.X, (float)point.Y, Colors.FromARGB(0xFF, 0xFE, 0xF9, 0xE1));

		}
	}
}
