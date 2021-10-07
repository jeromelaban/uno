#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpLightDismiss : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpLightDismiss.Dismissed.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpLightDismiss.Dismissed.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpLightDismiss GetForWindowId( global::Microsoft.UI.WindowId windowId)
		{
			throw new global::System.NotImplementedException("The member ExpLightDismiss ExpLightDismiss.GetForWindowId(WindowId windowId) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpLightDismiss, global::Microsoft.UI.Input.Experimental.ExpLightDismissEventArgs> Dismissed
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpLightDismiss", "event TypedEventHandler<ExpLightDismiss, ExpLightDismissEventArgs> ExpLightDismiss.Dismissed");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpLightDismiss", "event TypedEventHandler<ExpLightDismiss, ExpLightDismissEventArgs> ExpLightDismiss.Dismissed");
			}
		}
		#endif
	}
}
