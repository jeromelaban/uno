#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpManipulationStartedEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Input.ManipulationDelta Cumulative
		{
			get
			{
				throw new global::System.NotImplementedException("The member ManipulationDelta ExpManipulationStartedEventArgs.Cumulative is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Devices.Input.PointerDeviceType PointerDeviceType
		{
			get
			{
				throw new global::System.NotImplementedException("The member PointerDeviceType ExpManipulationStartedEventArgs.PointerDeviceType is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Point Position
		{
			get
			{
				throw new global::System.NotImplementedException("The member Point ExpManipulationStartedEventArgs.Position is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpManipulationStartedEventArgs.Cumulative.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpManipulationStartedEventArgs.PointerDeviceType.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpManipulationStartedEventArgs.Position.get
	}
}
