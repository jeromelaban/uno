#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Activation
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IDialReceiverActivatedEventArgs : global::Windows.ApplicationModel.Activation.ILaunchActivatedEventArgs,global::Windows.ApplicationModel.Activation.IActivatedEventArgs
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		string AppName
		{
			get;
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Activation.IDialReceiverActivatedEventArgs.AppName.get
	}
}
