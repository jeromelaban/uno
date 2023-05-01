#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionRoundedRectangleGeometry : global::Microsoft.UI.Composition.CompositionGeometry
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::System.Numerics.Vector2 Size
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionRoundedRectangleGeometry.Size is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionRoundedRectangleGeometry.Size");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionRoundedRectangleGeometry", "Vector2 CompositionRoundedRectangleGeometry.Size");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::System.Numerics.Vector2 Offset
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionRoundedRectangleGeometry.Offset is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionRoundedRectangleGeometry.Offset");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionRoundedRectangleGeometry", "Vector2 CompositionRoundedRectangleGeometry.Offset");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::System.Numerics.Vector2 CornerRadius
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionRoundedRectangleGeometry.CornerRadius is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionRoundedRectangleGeometry.CornerRadius");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionRoundedRectangleGeometry", "Vector2 CompositionRoundedRectangleGeometry.CornerRadius");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.Size.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.CornerRadius.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.CornerRadius.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.Size.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.Offset.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionRoundedRectangleGeometry.Offset.get
	}
}
