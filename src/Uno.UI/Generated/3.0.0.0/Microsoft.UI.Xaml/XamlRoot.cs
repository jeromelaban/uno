#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class XamlRoot 
	{
		// Skipping already declared property Content
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsHostVisible
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool XamlRoot.IsHostVisible is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  double RasterizationScale
		{
			get
			{
				throw new global::System.NotImplementedException("The member double XamlRoot.RasterizationScale is not implemented in Uno.");
			}
		}
		#endif
		// Skipping already declared property Size
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.Content.get
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.Size.get
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.RasterizationScale.get
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.IsHostVisible.get
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.Changed.add
		// Forced skipping of method Microsoft.UI.Xaml.XamlRoot.Changed.remove
		// Skipping already declared event Microsoft.UI.Xaml.XamlRoot.Changed
	}
}
