#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition.Interactions
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class InteractionTrackerIdleStateEnteredArgs 
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int RequestId
		{
			get
			{
				throw new global::System.NotImplementedException("The member int InteractionTrackerIdleStateEnteredArgs.RequestId is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20InteractionTrackerIdleStateEnteredArgs.RequestId");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsFromBinding
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool InteractionTrackerIdleStateEnteredArgs.IsFromBinding is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20InteractionTrackerIdleStateEnteredArgs.IsFromBinding");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.Interactions.InteractionTrackerIdleStateEnteredArgs.IsFromBinding.get
		// Forced skipping of method Microsoft.UI.Composition.Interactions.InteractionTrackerIdleStateEnteredArgs.RequestId.get
	}
}
