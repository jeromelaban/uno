#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Dispatching
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class DispatcherQueueTimer 
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsRepeating
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool DispatcherQueueTimer.IsRepeating is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20DispatcherQueueTimer.IsRepeating");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "bool DispatcherQueueTimer.IsRepeating");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.TimeSpan Interval
		{
			get
			{
				throw new global::System.NotImplementedException("The member TimeSpan DispatcherQueueTimer.Interval is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=TimeSpan%20DispatcherQueueTimer.Interval");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "TimeSpan DispatcherQueueTimer.Interval");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsRunning
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool DispatcherQueueTimer.IsRunning is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20DispatcherQueueTimer.IsRunning");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.IsRepeating.get
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.Interval.set
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.IsRunning.get
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.Interval.get
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.IsRepeating.set
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void Start()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "void DispatcherQueueTimer.Start()");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void Stop()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "void DispatcherQueueTimer.Stop()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.Tick.add
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueueTimer.Tick.remove
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Dispatching.DispatcherQueueTimer, object> Tick
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "event TypedEventHandler<DispatcherQueueTimer, object> DispatcherQueueTimer.Tick");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueueTimer", "event TypedEventHandler<DispatcherQueueTimer, object> DispatcherQueueTimer.Tick");
			}
		}
		#endif
	}
}
