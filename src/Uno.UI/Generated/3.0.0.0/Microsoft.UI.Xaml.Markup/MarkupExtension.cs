#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Markup
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class MarkupExtension 
	{
		// Skipping already declared method Microsoft.UI.Xaml.Markup.MarkupExtension.MarkupExtension()
		// Forced skipping of method Microsoft.UI.Xaml.Markup.MarkupExtension.MarkupExtension()
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		protected virtual object ProvideValue()
		{
			throw new global::System.NotImplementedException("The member object MarkupExtension.ProvideValue() is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		protected virtual object ProvideValue( global::Microsoft.UI.Xaml.IXamlServiceProvider serviceProvider)
		{
			throw new global::System.NotImplementedException("The member object MarkupExtension.ProvideValue(IXamlServiceProvider serviceProvider) is not implemented in Uno.");
		}
		#endif
	}
}
