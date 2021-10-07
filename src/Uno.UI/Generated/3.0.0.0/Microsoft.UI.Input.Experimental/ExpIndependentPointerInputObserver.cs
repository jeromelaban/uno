#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpIndependentPointerInputObserver : global::Microsoft.UI.Input.Experimental.ExpPointerInputObserver
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpIndependentPointerInputObserver CreateForVisual( global::Microsoft.UI.Composition.Visual visual,  global::Windows.UI.Core.CoreInputDeviceTypes deviceTypes)
		{
			throw new global::System.NotImplementedException("The member ExpIndependentPointerInputObserver ExpIndependentPointerInputObserver.CreateForVisual(Visual visual, CoreInputDeviceTypes deviceTypes) is not implemented in Uno.");
		}
		#endif
	}
}
