#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpFocusNavigationRequest 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Guid CorrelationId
		{
			get
			{
				throw new global::System.NotImplementedException("The member Guid ExpFocusNavigationRequest.CorrelationId is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Rect HintRect
		{
			get
			{
				throw new global::System.NotImplementedException("The member Rect ExpFocusNavigationRequest.HintRect is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Input.Experimental.ExpFocusNavigationReason Reason
		{
			get
			{
				throw new global::System.NotImplementedException("The member ExpFocusNavigationReason ExpFocusNavigationRequest.Reason is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest.CorrelationId.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest.HintRect.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest.Reason.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest CreateFocusNavigationRequestReasonAndHintRect( global::Microsoft.UI.Input.Experimental.ExpFocusNavigationReason reason,  global::Windows.Foundation.Rect hintRect)
		{
			throw new global::System.NotImplementedException("The member ExpFocusNavigationRequest ExpFocusNavigationRequest.CreateFocusNavigationRequestReasonAndHintRect(ExpFocusNavigationReason reason, Rect hintRect) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest CreateFocusNavigationRequestReasonHintRectAndId( global::Microsoft.UI.Input.Experimental.ExpFocusNavigationReason reason,  global::Windows.Foundation.Rect hintRect,  global::System.Guid correlationId)
		{
			throw new global::System.NotImplementedException("The member ExpFocusNavigationRequest ExpFocusNavigationRequest.CreateFocusNavigationRequestReasonHintRectAndId(ExpFocusNavigationReason reason, Rect hintRect, Guid correlationId) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpFocusNavigationRequest CreateFocusNavigationRequestWithReason( global::Microsoft.UI.Input.Experimental.ExpFocusNavigationReason reason)
		{
			throw new global::System.NotImplementedException("The member ExpFocusNavigationRequest ExpFocusNavigationRequest.CreateFocusNavigationRequestWithReason(ExpFocusNavigationReason reason) is not implemented in Uno.");
		}
		#endif
	}
}
