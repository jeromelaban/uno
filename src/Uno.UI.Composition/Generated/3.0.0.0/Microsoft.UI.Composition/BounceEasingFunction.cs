#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class BounceEasingFunction : global::Microsoft.UI.Composition.CompositionEasingFunction
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int Bounces
		{
			get
			{
				throw new global::System.NotImplementedException("The member int BounceEasingFunction.Bounces is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20BounceEasingFunction.Bounces");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  float Bounciness
		{
			get
			{
				throw new global::System.NotImplementedException("The member float BounceEasingFunction.Bounciness is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=float%20BounceEasingFunction.Bounciness");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Composition.CompositionEasingFunctionMode Mode
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionEasingFunctionMode BounceEasingFunction.Mode is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionEasingFunctionMode%20BounceEasingFunction.Mode");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.BounceEasingFunction.Bounciness.get
		// Forced skipping of method Microsoft.UI.Composition.BounceEasingFunction.Mode.get
		// Forced skipping of method Microsoft.UI.Composition.BounceEasingFunction.Bounces.get
	}
}
