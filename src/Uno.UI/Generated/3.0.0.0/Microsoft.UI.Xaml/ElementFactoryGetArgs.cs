#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ElementFactoryGetArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.UIElement Parent
		{
			get
			{
				throw new global::System.NotImplementedException("The member UIElement ElementFactoryGetArgs.Parent is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=UIElement%20ElementFactoryGetArgs.Parent");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.ElementFactoryGetArgs", "UIElement ElementFactoryGetArgs.Parent");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  object Data
		{
			get
			{
				throw new global::System.NotImplementedException("The member object ElementFactoryGetArgs.Data is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=object%20ElementFactoryGetArgs.Data");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.ElementFactoryGetArgs", "object ElementFactoryGetArgs.Data");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public ElementFactoryGetArgs() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.ElementFactoryGetArgs", "ElementFactoryGetArgs.ElementFactoryGetArgs()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.ElementFactoryGetArgs.ElementFactoryGetArgs()
		// Forced skipping of method Microsoft.UI.Xaml.ElementFactoryGetArgs.Data.get
		// Forced skipping of method Microsoft.UI.Xaml.ElementFactoryGetArgs.Data.set
		// Forced skipping of method Microsoft.UI.Xaml.ElementFactoryGetArgs.Parent.get
		// Forced skipping of method Microsoft.UI.Xaml.ElementFactoryGetArgs.Parent.set
	}
}
