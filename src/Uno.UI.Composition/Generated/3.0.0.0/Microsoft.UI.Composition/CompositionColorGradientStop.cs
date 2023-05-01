#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionColorGradientStop : global::Microsoft.UI.Composition.CompositionObject
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  float Offset
		{
			get
			{
				throw new global::System.NotImplementedException("The member float CompositionColorGradientStop.Offset is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=float%20CompositionColorGradientStop.Offset");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionColorGradientStop", "float CompositionColorGradientStop.Offset");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Windows.UI.Color Color
		{
			get
			{
				throw new global::System.NotImplementedException("The member Color CompositionColorGradientStop.Color is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Color%20CompositionColorGradientStop.Color");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionColorGradientStop", "Color CompositionColorGradientStop.Color");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorGradientStop.Offset.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorGradientStop.Color.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorGradientStop.Color.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorGradientStop.Offset.get
	}
}
