#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class ScalarKeyFrameAnimation : global::Microsoft.UI.Composition.KeyFrameAnimation
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void InsertKeyFrame( float normalizedProgressKey,  float value)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.ScalarKeyFrameAnimation", "void ScalarKeyFrameAnimation.InsertKeyFrame(float normalizedProgressKey, float value)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void InsertKeyFrame( float normalizedProgressKey,  float value,  global::Microsoft.UI.Composition.CompositionEasingFunction easingFunction)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.ScalarKeyFrameAnimation", "void ScalarKeyFrameAnimation.InsertKeyFrame(float normalizedProgressKey, float value, CompositionEasingFunction easingFunction)");
		}
		#endif
	}
}
