#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::System.FlagsAttribute]
	public   enum CompositionBatchTypes : uint
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		None = 0,
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		Animation = 1,
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		Effect = 2,
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		InfiniteAnimation = 4,
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		AllAnimations = 5,
		#endif
	}
	#endif
}
