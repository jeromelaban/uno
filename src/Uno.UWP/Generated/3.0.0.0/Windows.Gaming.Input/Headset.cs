#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Gaming.Input
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class Headset : global::Windows.Gaming.Input.IGameControllerBatteryInfo
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string CaptureDeviceId
		{
			get
			{
				throw new global::System.NotImplementedException("The member string Headset.CaptureDeviceId is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20Headset.CaptureDeviceId");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string RenderDeviceId
		{
			get
			{
				throw new global::System.NotImplementedException("The member string Headset.RenderDeviceId is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20Headset.RenderDeviceId");
			}
		}
		#endif
		// Forced skipping of method Windows.Gaming.Input.Headset.CaptureDeviceId.get
		// Forced skipping of method Windows.Gaming.Input.Headset.RenderDeviceId.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Devices.Power.BatteryReport TryGetBatteryReport()
		{
			throw new global::System.NotImplementedException("The member BatteryReport Headset.TryGetBatteryReport() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=BatteryReport%20Headset.TryGetBatteryReport%28%29");
		}
		#endif
		// Processing: Windows.Gaming.Input.IGameControllerBatteryInfo
	}
}
