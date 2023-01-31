#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Media.Miracast
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class MiracastTransmitter 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string Name
		{
			get
			{
				throw new global::System.NotImplementedException("The member string MiracastTransmitter.Name is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20MiracastTransmitter.Name");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Media.Miracast.MiracastTransmitter", "string MiracastTransmitter.Name");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Media.Miracast.MiracastTransmitterAuthorizationStatus AuthorizationStatus
		{
			get
			{
				throw new global::System.NotImplementedException("The member MiracastTransmitterAuthorizationStatus MiracastTransmitter.AuthorizationStatus is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=MiracastTransmitterAuthorizationStatus%20MiracastTransmitter.AuthorizationStatus");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Media.Miracast.MiracastTransmitter", "MiracastTransmitterAuthorizationStatus MiracastTransmitter.AuthorizationStatus");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.DateTimeOffset LastConnectionTime
		{
			get
			{
				throw new global::System.NotImplementedException("The member DateTimeOffset MiracastTransmitter.LastConnectionTime is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=DateTimeOffset%20MiracastTransmitter.LastConnectionTime");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string MacAddress
		{
			get
			{
				throw new global::System.NotImplementedException("The member string MiracastTransmitter.MacAddress is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20MiracastTransmitter.MacAddress");
			}
		}
		#endif
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.Name.get
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.Name.set
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.AuthorizationStatus.get
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.AuthorizationStatus.set
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Collections.Generic.IReadOnlyList<global::Windows.Media.Miracast.MiracastReceiverConnection> GetConnections()
		{
			throw new global::System.NotImplementedException("The member IReadOnlyList<MiracastReceiverConnection> MiracastTransmitter.GetConnections() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IReadOnlyList%3CMiracastReceiverConnection%3E%20MiracastTransmitter.GetConnections%28%29");
		}
		#endif
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.MacAddress.get
		// Forced skipping of method Windows.Media.Miracast.MiracastTransmitter.LastConnectionTime.get
	}
}
