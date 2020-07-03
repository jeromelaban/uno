#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Capture.Frames
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public   enum MultiSourceMediaFrameReaderStartStatus 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		Success,
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		NotSupported,
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		InsufficientResources,
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		DeviceNotAvailable,
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		UnknownFailure,
		#endif
	}
	#endif
}
