#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Data
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface INotifyPropertyChanged 
	{
		// Forced skipping of method Microsoft.UI.Xaml.Data.INotifyPropertyChanged.PropertyChanged.add
		// Forced skipping of method Microsoft.UI.Xaml.Data.INotifyPropertyChanged.PropertyChanged.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		 event global::System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		#endif
	}
}
