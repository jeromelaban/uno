#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionRectangleGeometry : global::Microsoft.UI.Composition.CompositionGeometry
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::System.Numerics.Vector2 Size
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionRectangleGeometry.Size is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionRectangleGeometry.Size");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionRectangleGeometry", "Vector2 CompositionRectangleGeometry.Size");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::System.Numerics.Vector2 Offset
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionRectangleGeometry.Offset is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionRectangleGeometry.Offset");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionRectangleGeometry", "Vector2 CompositionRectangleGeometry.Offset");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionRectangleGeometry.Size.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionRectangleGeometry.Size.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionRectangleGeometry.Offset.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionRectangleGeometry.Offset.set
	}
}
