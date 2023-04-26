#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class CompositionLineGeometry : global::Microsoft.UI.Composition.CompositionGeometry
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Numerics.Vector2 Start
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionLineGeometry.Start is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionLineGeometry.Start");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionLineGeometry", "Vector2 CompositionLineGeometry.Start");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Numerics.Vector2 End
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector2 CompositionLineGeometry.End is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector2%20CompositionLineGeometry.End");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionLineGeometry", "Vector2 CompositionLineGeometry.End");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionLineGeometry.End.get
		// Forced skipping of method Microsoft.UI.Composition.CompositionLineGeometry.End.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionLineGeometry.Start.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionLineGeometry.Start.get
	}
}
