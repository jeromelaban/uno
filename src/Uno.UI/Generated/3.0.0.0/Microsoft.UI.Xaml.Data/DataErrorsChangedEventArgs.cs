#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Data
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class DataErrorsChangedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string PropertyName
		{
			get
			{
				throw new global::System.NotImplementedException("The member string DataErrorsChangedEventArgs.PropertyName is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20DataErrorsChangedEventArgs.PropertyName");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Data.DataErrorsChangedEventArgs", "string DataErrorsChangedEventArgs.PropertyName");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public DataErrorsChangedEventArgs( string name) 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Data.DataErrorsChangedEventArgs", "DataErrorsChangedEventArgs.DataErrorsChangedEventArgs(string name)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Data.DataErrorsChangedEventArgs.DataErrorsChangedEventArgs(string)
		// Forced skipping of method Microsoft.UI.Xaml.Data.DataErrorsChangedEventArgs.PropertyName.get
		// Forced skipping of method Microsoft.UI.Xaml.Data.DataErrorsChangedEventArgs.PropertyName.set
	}
}
