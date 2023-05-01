#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class ShapeVisual : global::Microsoft.UI.Composition.ContainerVisual
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Microsoft.UI.Composition.CompositionViewBox ViewBox
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionViewBox ShapeVisual.ViewBox is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionViewBox%20ShapeVisual.ViewBox");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.ShapeVisual", "CompositionViewBox ShapeVisual.ViewBox");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Microsoft.UI.Composition.CompositionShapeCollection Shapes
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionShapeCollection ShapeVisual.Shapes is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionShapeCollection%20ShapeVisual.Shapes");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.ShapeVisual.Shapes.get
		// Forced skipping of method Microsoft.UI.Composition.ShapeVisual.ViewBox.get
		// Forced skipping of method Microsoft.UI.Composition.ShapeVisual.ViewBox.set
	}
}
