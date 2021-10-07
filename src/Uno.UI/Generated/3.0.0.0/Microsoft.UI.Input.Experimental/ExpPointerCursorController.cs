#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpPointerCursorController : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Core.CoreCursor Cursor
		{
			get
			{
				throw new global::System.NotImplementedException("The member CoreCursor ExpPointerCursorController.Cursor is not implemented in Uno.");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpPointerCursorController", "CoreCursor ExpPointerCursorController.Cursor");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Point Position
		{
			get
			{
				throw new global::System.NotImplementedException("The member Point ExpPointerCursorController.Position is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpPointerCursorController.Cursor.get
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpPointerCursorController.Cursor.set
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpPointerCursorController.Position.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpPointerCursorController GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpPointerCursorController ExpPointerCursorController.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
	}
}
