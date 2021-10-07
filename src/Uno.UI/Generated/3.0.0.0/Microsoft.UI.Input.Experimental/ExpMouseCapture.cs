#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpMouseCapture : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool HasCapture
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool ExpMouseCapture.HasCapture is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpMouseCapture.HasCapture.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TryReleaseCapture()
		{
			throw new global::System.NotImplementedException("The member bool ExpMouseCapture.TryReleaseCapture() is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TrySetCapture()
		{
			throw new global::System.NotImplementedException("The member bool ExpMouseCapture.TrySetCapture() is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpMouseCapture GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpMouseCapture ExpMouseCapture.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
	}
}
