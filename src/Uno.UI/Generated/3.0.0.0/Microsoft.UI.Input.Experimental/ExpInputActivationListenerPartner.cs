#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpInputActivationListenerPartner 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static object GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member object ExpInputActivationListenerPartner.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
	}
}
