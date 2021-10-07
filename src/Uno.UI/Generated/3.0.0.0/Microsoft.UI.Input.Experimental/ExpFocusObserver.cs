#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpFocusObserver : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool HasFocus
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool ExpFocusObserver.HasFocus is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusObserver.HasFocus.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusObserver.GotFocus.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusObserver.GotFocus.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusObserver.LostFocus.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusObserver.LostFocus.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpFocusObserver CreateForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpFocusObserver ExpFocusObserver.CreateForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpFocusObserver, global::Microsoft.UI.Input.Experimental.ExpFocusChangedEventArgs> GotFocus
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusObserver", "event TypedEventHandler<ExpFocusObserver, ExpFocusChangedEventArgs> ExpFocusObserver.GotFocus");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusObserver", "event TypedEventHandler<ExpFocusObserver, ExpFocusChangedEventArgs> ExpFocusObserver.GotFocus");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpFocusObserver, global::Microsoft.UI.Input.Experimental.ExpFocusChangedEventArgs> LostFocus
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusObserver", "event TypedEventHandler<ExpFocusObserver, ExpFocusChangedEventArgs> ExpFocusObserver.LostFocus");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpFocusObserver", "event TypedEventHandler<ExpFocusObserver, ExpFocusChangedEventArgs> ExpFocusObserver.LostFocus");
			}
		}
		#endif
	}
}
