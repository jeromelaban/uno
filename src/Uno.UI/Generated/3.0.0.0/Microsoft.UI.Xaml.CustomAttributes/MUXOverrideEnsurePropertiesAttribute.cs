#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.CustomAttributes
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class MUXOverrideEnsurePropertiesAttribute : global::System.Attribute
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public MUXOverrideEnsurePropertiesAttribute() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.CustomAttributes.MUXOverrideEnsurePropertiesAttribute", "MUXOverrideEnsurePropertiesAttribute.MUXOverrideEnsurePropertiesAttribute()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.CustomAttributes.MUXOverrideEnsurePropertiesAttribute.MUXOverrideEnsurePropertiesAttribute()
	}
}
