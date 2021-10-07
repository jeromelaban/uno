#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Markup
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IProvideValueTarget 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		object TargetObject
		{
			get;
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		object TargetProperty
		{
			get;
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Markup.IProvideValueTarget.TargetObject.get
		// Forced skipping of method Microsoft.UI.Xaml.Markup.IProvideValueTarget.TargetProperty.get
	}
}
