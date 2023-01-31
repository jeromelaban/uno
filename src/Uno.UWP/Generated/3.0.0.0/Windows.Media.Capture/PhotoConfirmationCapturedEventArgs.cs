#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Capture
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class PhotoConfirmationCapturedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.TimeSpan CaptureTimeOffset
		{
			get
			{
				throw new global::System.NotImplementedException("The member TimeSpan PhotoConfirmationCapturedEventArgs.CaptureTimeOffset is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=TimeSpan%20PhotoConfirmationCapturedEventArgs.CaptureTimeOffset");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Media.Capture.CapturedFrame Frame
		{
			get
			{
				throw new global::System.NotImplementedException("The member CapturedFrame PhotoConfirmationCapturedEventArgs.Frame is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=CapturedFrame%20PhotoConfirmationCapturedEventArgs.Frame");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.Capture.PhotoConfirmationCapturedEventArgs.Frame.get
		// Forced skipping of method Windows.Media.Capture.PhotoConfirmationCapturedEventArgs.CaptureTimeOffset.get
	}
}
