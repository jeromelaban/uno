#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	public   enum CompositionMappingMode 
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		Absolute = 0,
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		Relative = 1,
		#endif
	}
	#endif
}
