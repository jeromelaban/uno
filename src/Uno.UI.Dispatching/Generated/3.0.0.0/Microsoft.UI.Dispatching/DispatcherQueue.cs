#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Dispatching
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
	#endif
	public  partial class DispatcherQueue 
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool HasThreadAccess
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool DispatcherQueue.HasThreadAccess is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20DispatcherQueue.HasThreadAccess");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TryEnqueue( global::Microsoft.UI.Dispatching.DispatcherQueuePriority priority,  global::Microsoft.UI.Dispatching.DispatcherQueueHandler callback)
		{
			throw new global::System.NotImplementedException("The member bool DispatcherQueue.TryEnqueue(DispatcherQueuePriority priority, DispatcherQueueHandler callback) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20DispatcherQueue.TryEnqueue%28DispatcherQueuePriority%20priority%2C%20DispatcherQueueHandler%20callback%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Dispatching.DispatcherQueueTimer CreateTimer()
		{
			throw new global::System.NotImplementedException("The member DispatcherQueueTimer DispatcherQueue.CreateTimer() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=DispatcherQueueTimer%20DispatcherQueue.CreateTimer%28%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool TryEnqueue( global::Microsoft.UI.Dispatching.DispatcherQueueHandler callback)
		{
			throw new global::System.NotImplementedException("The member bool DispatcherQueue.TryEnqueue(DispatcherQueueHandler callback) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20DispatcherQueue.TryEnqueue%28DispatcherQueueHandler%20callback%29");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueue.ShutdownStarting.add
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueue.ShutdownStarting.remove
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueue.ShutdownCompleted.add
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueue.ShutdownCompleted.remove
		// Forced skipping of method Microsoft.UI.Dispatching.DispatcherQueue.HasThreadAccess.get
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Dispatching.DispatcherQueue GetForCurrentThread()
		{
			throw new global::System.NotImplementedException("The member DispatcherQueue DispatcherQueue.GetForCurrentThread() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=DispatcherQueue%20DispatcherQueue.GetForCurrentThread%28%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Dispatching.DispatcherQueue, object> ShutdownCompleted
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueue", "event TypedEventHandler<DispatcherQueue, object> DispatcherQueue.ShutdownCompleted");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueue", "event TypedEventHandler<DispatcherQueue, object> DispatcherQueue.ShutdownCompleted");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Dispatching.DispatcherQueue, global::Microsoft.UI.Dispatching.DispatcherQueueShutdownStartingEventArgs> ShutdownStarting
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueue", "event TypedEventHandler<DispatcherQueue, DispatcherQueueShutdownStartingEventArgs> DispatcherQueue.ShutdownStarting");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Dispatching.DispatcherQueue", "event TypedEventHandler<DispatcherQueue, DispatcherQueueShutdownStartingEventArgs> DispatcherQueue.ShutdownStarting");
			}
		}
		#endif
	}
}
