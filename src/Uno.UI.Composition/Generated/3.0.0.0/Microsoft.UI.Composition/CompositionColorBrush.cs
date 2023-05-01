#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionColorBrush : global::Microsoft.UI.Composition.CompositionBrush
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Windows.UI.Color Color
		{
			get
			{
				throw new global::System.NotImplementedException("The member Color CompositionColorBrush.Color is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Color%20CompositionColorBrush.Color");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionColorBrush", "Color CompositionColorBrush.Color");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorBrush.Color.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionColorBrush.Color.set
	}
}
