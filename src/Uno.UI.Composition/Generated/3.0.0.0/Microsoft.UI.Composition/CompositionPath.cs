#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class CompositionPath 
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public CompositionPath( global::Windows.Graphics.IGeometrySource2D source) 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionPath", "CompositionPath.CompositionPath(IGeometrySource2D source)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionPath.CompositionPath(Windows.Graphics.IGeometrySource2D)
	}
}
