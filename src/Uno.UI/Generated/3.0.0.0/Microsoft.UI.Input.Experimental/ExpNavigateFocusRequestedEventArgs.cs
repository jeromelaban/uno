#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpNavigateFocusRequestedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool WasMoved
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool ExpNavigateFocusRequestedEventArgs.WasMoved is not implemented in Uno.");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpNavigateFocusRequestedEventArgs", "bool ExpNavigateFocusRequestedEventArgs.WasMoved");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest Request
		{
			get
			{
				throw new global::System.NotImplementedException("The member ExpFocusNavigationRequest ExpNavigateFocusRequestedEventArgs.Request is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpNavigateFocusRequestedEventArgs.Request.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpNavigateFocusRequestedEventArgs.WasMoved.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpNavigateFocusRequestedEventArgs.WasMoved.set
	}
}
