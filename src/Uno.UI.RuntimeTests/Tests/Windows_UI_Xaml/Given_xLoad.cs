#nullable enable
#if !WINDOWS_UWP
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Private.Infrastructure;
using Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uno.UI.RuntimeTests.Tests.Windows_UI_Xaml
{
	[TestClass]
	[RunsOnUIThread]
	public class Given_xLoad
	{
		[TestMethod]
		[RunsOnUIThread]
		public async Task When_xLoad_Literal()
		{
			var sut = new xLoad_Literal();

			TestServices.WindowHelper.WindowContent = sut;
			var loadBorderFalse = sut.LoadBorderFalse;
			var loadBorderTrue = sut.LoadBorderTrue;

			Assert.IsNull(loadBorderFalse);
			Assert.IsNotNull(loadBorderTrue);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_xLoad_xBind()
		{
			var sut = new xLoad_xBind();

			TestServices.WindowHelper.WindowContent = sut;
			TestServices.WindowHelper.WaitForLoaded(sut);

			var loadBorder = sut.LoadBorder;
			Assert.IsNull(sut.LoadBorder);

			sut.IsLoad = true;

			Assert.IsNotNull(sut.LoadBorder);
			var parent = sut.LoadBorder.Parent as Border;

			sut.IsLoad = false;

			Assert.IsFalse((parent.Child as ElementStub).Load);

			sut.IsLoad = true;

			Assert.IsNotNull(sut.LoadBorder);
			parent = sut.LoadBorder.Parent as Border;

			sut.IsLoad = false;

			Assert.IsFalse((parent.Child as ElementStub).Load);
		}

		[TestMethod]
		[RunsOnUIThread]
		public void When_xLoad_Visibility_While_Materializing()
		{
			var SUT = new When_xLoad_Visibility_While_Materializing();

			Assert.AreEqual(0, When_xLoad_Visibility_While_Materializing_Content.Instances);

			TestServices.WindowHelper.WindowContent = SUT;

			Assert.AreEqual(0, When_xLoad_Visibility_While_Materializing_Content.Instances);

			SUT.Model.IsVisible = true;

			Assert.AreEqual(1, When_xLoad_Visibility_While_Materializing_Content.Instances);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_xLoad_xBind_xLoad_Initial()
		{
			var grid = new Grid();
			TestServices.WindowHelper.WindowContent = grid;

			var SUT = new When_xLoad_xBind_xLoad_Initial();
			grid.Children.Add(SUT);

			Assert.IsNotNull(SUT.tb01);
			Assert.AreEqual(1, SUT.tb01.Tag);

			SUT.Model.MyValue = 42;

			Assert.AreEqual(42, SUT.tb01.Tag);
		}

		[TestMethod]
		[RunsOnUIThread]
		public async Task When_xLoad_xBind_xLoad_While_Loading()
		{
			var grid = new Grid();
			TestServices.WindowHelper.WindowContent = grid;

			var SUT = new When_xLoad_xBind_xLoad_While_Loading();
			grid.Children.Add(SUT);

			Assert.IsNotNull(SUT.tb01);
			Assert.AreEqual(1, SUT.tb01.Tag);

			SUT.Model.MyValue = 42;

			Assert.AreEqual(42, SUT.tb01.Tag);
		}


		[TestMethod]
		public async Task When_Binding_xLoad_Nested()
		{
			var SUT = new Binding_xLoad_Nested();
			Assert.IsNull(SUT.tb01);
			Assert.IsNull(SUT.tb02);
			Assert.IsNull(SUT.tb03);
			Assert.IsNull(SUT.tb04);
			Assert.IsNull(SUT.tb05);
			Assert.IsNull(SUT.tb06);

			Assert.AreEqual(0, SUT.TopLevelVisiblity1GetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity1SetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity2GetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity2SetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity3GetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity3SetCount);

			var grid = new Grid();
			TestServices.WindowHelper.WindowContent = grid;
			grid.Children.Add(SUT);

			Assert.IsNull(SUT.tb01);
			Assert.IsNull(SUT.tb02);
			Assert.IsNull(SUT.tb03);
			Assert.IsNull(SUT.tb04);
			Assert.IsNull(SUT.tb05);
			Assert.IsNull(SUT.tb06);

			Assert.AreEqual(2, SUT.TopLevelVisiblity1GetCount);
			Assert.AreEqual(0, SUT.TopLevelVisiblity1SetCount);

			SUT.TopLevelVisiblity1 = true;
			Assert.IsNotNull(SUT.tb01);
			Assert.IsNotNull(SUT.tb02);
			Assert.IsNull(SUT.tb03);
			Assert.IsNull(SUT.tb04);
			Assert.IsNull(SUT.tb05);
			Assert.IsNull(SUT.tb06);

			SUT.TopLevelVisiblity2 = true;
			Assert.IsNotNull(SUT.tb01);
			Assert.IsNotNull(SUT.tb02);
			Assert.IsNotNull(SUT.tb03);
			Assert.IsNull(SUT.tb04);
			Assert.IsNotNull(SUT.tb05);
			Assert.IsNull(SUT.tb06);

			SUT.TopLevelVisiblity3 = true;
			Assert.IsNotNull(SUT.tb01);
			Assert.IsNotNull(SUT.tb02);
			Assert.IsNotNull(SUT.tb03);
			Assert.IsNotNull(SUT.panel02);
			Assert.IsNotNull(SUT.tb04);
			Assert.IsNotNull(SUT.tb05);
			Assert.IsNotNull(SUT.tb06);

			SUT.TopLevelVisiblity3 = false;

			Assert.IsNotNull(SUT.tb01);
			Assert.IsNotNull(SUT.tb02);
			Assert.IsNotNull(SUT.tb03);
			await AssertIsNullAsync(() => SUT.panel02);
			await AssertIsNullAsync(() => SUT.tb04);
			Assert.IsNotNull(SUT.tb05);
			await AssertIsNullAsync(() => SUT.tb06);

			SUT.TopLevelVisiblity2 = false;

			Assert.IsNotNull(SUT.tb01);
			Assert.IsNotNull(SUT.tb02);
			await AssertIsNullAsync(() => SUT.panel01);
			await AssertIsNullAsync(() => SUT.tb03);
			await AssertIsNullAsync(() => SUT.panel02);
			await AssertIsNullAsync(() => SUT.tb04);
			await AssertIsNullAsync(() => SUT.tb05);
			await AssertIsNullAsync(() => SUT.tb06);

			SUT.TopLevelVisiblity1 = false;

			await AssertIsNullAsync(() => SUT.tb01);
			await AssertIsNullAsync(() => SUT.tb02);
			await AssertIsNullAsync(() => SUT.tb03);
			await AssertIsNullAsync(() => SUT.panel02);
			await AssertIsNullAsync(() => SUT.tb04);
			await AssertIsNullAsync(() => SUT.tb05);
			await AssertIsNullAsync(() => SUT.tb06);
		}

		private async Task AssertIsNullAsync<T>(Func<T> getter, TimeSpan? timeout = null)
		{
			timeout ??= TimeSpan.FromSeconds(5);
			var sw = Stopwatch.StartNew();

			while (sw.Elapsed < timeout && getter() != null)
			{
				await Task.Delay(100);

				// Wait for the ElementNameSubject and ComponentHolder
				// instances to release their references.
				GC.Collect(2);
				GC.WaitForPendingFinalizers();
			}

			Assert.IsNull(getter());
		}
	}
}
#endif
