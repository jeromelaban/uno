#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Automation.Peers
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ListBoxItemDataAutomationPeer : global::Microsoft.UI.Xaml.Automation.Peers.SelectorItemAutomationPeer,global::Microsoft.UI.Xaml.Automation.Provider.IScrollItemProvider
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public ListBoxItemDataAutomationPeer( object item,  global::Microsoft.UI.Xaml.Automation.Peers.ListBoxAutomationPeer parent) : base(item, parent)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Automation.Peers.ListBoxItemDataAutomationPeer", "ListBoxItemDataAutomationPeer.ListBoxItemDataAutomationPeer(object item, ListBoxAutomationPeer parent)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Automation.Peers.ListBoxItemDataAutomationPeer.ListBoxItemDataAutomationPeer(object, Microsoft.UI.Xaml.Automation.Peers.ListBoxAutomationPeer)
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void ScrollIntoView()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Automation.Peers.ListBoxItemDataAutomationPeer", "void ListBoxItemDataAutomationPeer.ScrollIntoView()");
		}
		#endif
		// Processing: Microsoft.UI.Xaml.Automation.Provider.IScrollItemProvider
	}
}
