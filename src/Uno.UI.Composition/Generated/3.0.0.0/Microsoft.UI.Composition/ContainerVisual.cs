#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class ContainerVisual : global::Microsoft.UI.Composition.Visual
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Composition.VisualCollection Children
		{
			get
			{
				throw new global::System.NotImplementedException("The member VisualCollection ContainerVisual.Children is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=VisualCollection%20ContainerVisual.Children");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.ContainerVisual.Children.get
	}
}
