#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpFocusNavigationHost : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Input.Experimental.ExpFocusNavigationResult NavigateFocus( global::Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest request)
		{
			throw new global::System.NotImplementedException("The member ExpFocusNavigationResult ExpFocusNavigationHost.NavigateFocus(ExpFocusNavigationRequest request) is not implemented in Uno.");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusNavigationHost.TakeFocusRequested.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusNavigationHost.TakeFocusRequested.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpFocusNavigationHost GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpFocusNavigationHost ExpFocusNavigationHost.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpFocusNavigationHost, global::Microsoft.UI.Input.Experimental.ExpNavigateFocusRequestedEventArgs> TakeFocusRequested
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusNavigationHost", "event TypedEventHandler<ExpFocusNavigationHost, ExpNavigateFocusRequestedEventArgs> ExpFocusNavigationHost.TakeFocusRequested");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusNavigationHost", "event TypedEventHandler<ExpFocusNavigationHost, ExpNavigateFocusRequestedEventArgs> ExpFocusNavigationHost.TakeFocusRequested");
			}
		}
		#endif
	}
}
