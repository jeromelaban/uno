#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpDirectManipulation : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpDirectManipulation.DirectManipulationHitTest.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpDirectManipulation.DirectManipulationHitTest.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpDirectManipulation GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpDirectManipulation ExpDirectManipulation.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpDirectManipulation, global::Microsoft.UI.Input.Experimental.ExpPointerEventArgs> DirectManipulationHitTest
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpDirectManipulation", "event TypedEventHandler<ExpDirectManipulation, ExpPointerEventArgs> ExpDirectManipulation.DirectManipulationHitTest");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpDirectManipulation", "event TypedEventHandler<ExpDirectManipulation, ExpPointerEventArgs> ExpDirectManipulation.DirectManipulationHitTest");
			}
		}
		#endif
	}
}
