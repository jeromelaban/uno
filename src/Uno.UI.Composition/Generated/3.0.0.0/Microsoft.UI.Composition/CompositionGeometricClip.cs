#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionGeometricClip : global::Microsoft.UI.Composition.CompositionClip
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Microsoft.UI.Composition.CompositionViewBox ViewBox
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionViewBox CompositionGeometricClip.ViewBox is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionViewBox%20CompositionGeometricClip.ViewBox");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionGeometricClip", "CompositionViewBox CompositionGeometricClip.ViewBox");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Microsoft.UI.Composition.CompositionGeometry Geometry
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionGeometry CompositionGeometricClip.Geometry is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionGeometry%20CompositionGeometricClip.Geometry");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionGeometricClip", "CompositionGeometry CompositionGeometricClip.Geometry");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionGeometricClip.ViewBox.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionGeometricClip.Geometry.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionGeometricClip.Geometry.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionGeometricClip.ViewBox.get
	}
}
