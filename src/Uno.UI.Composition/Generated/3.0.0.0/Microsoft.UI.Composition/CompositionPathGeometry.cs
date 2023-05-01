#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionPathGeometry : global::Microsoft.UI.Composition.CompositionGeometry
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  global::Microsoft.UI.Composition.CompositionPath Path
		{
			get
			{
				throw new global::System.NotImplementedException("The member CompositionPath CompositionPathGeometry.Path is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CompositionPath%20CompositionPathGeometry.Path");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionPathGeometry", "CompositionPath CompositionPathGeometry.Path");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionPathGeometry.Path.set
		// Forced skipping of method Microsoft.UI.Composition.CompositionPathGeometry.Path.get
	}
}
