#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class TextControlCopyingToClipboardEventArgs 
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool Handled
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool TextControlCopyingToClipboardEventArgs.Handled is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20TextControlCopyingToClipboardEventArgs.Handled");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.TextControlCopyingToClipboardEventArgs", "bool TextControlCopyingToClipboardEventArgs.Handled");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.TextControlCopyingToClipboardEventArgs.Handled.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.TextControlCopyingToClipboardEventArgs.Handled.set
	}
}
