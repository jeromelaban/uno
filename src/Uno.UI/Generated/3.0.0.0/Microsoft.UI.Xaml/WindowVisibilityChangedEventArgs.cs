#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class WindowVisibilityChangedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool Handled
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool WindowVisibilityChangedEventArgs.Handled is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20WindowVisibilityChangedEventArgs.Handled");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.WindowVisibilityChangedEventArgs", "bool WindowVisibilityChangedEventArgs.Handled");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool Visible
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool WindowVisibilityChangedEventArgs.Visible is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20WindowVisibilityChangedEventArgs.Visible");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.WindowVisibilityChangedEventArgs.Handled.get
		// Forced skipping of method Microsoft.UI.Xaml.WindowVisibilityChangedEventArgs.Handled.set
		// Forced skipping of method Microsoft.UI.Xaml.WindowVisibilityChangedEventArgs.Visible.get
	}
}
