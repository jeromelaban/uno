#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Automation.Peers
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class AppBarToggleButtonAutomationPeer : global::Microsoft.UI.Xaml.Automation.Peers.ToggleButtonAutomationPeer
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public AppBarToggleButtonAutomationPeer( global::Microsoft.UI.Xaml.Controls.AppBarToggleButton owner) : base(owner)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Automation.Peers.AppBarToggleButtonAutomationPeer", "AppBarToggleButtonAutomationPeer.AppBarToggleButtonAutomationPeer(AppBarToggleButton owner)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Automation.Peers.AppBarToggleButtonAutomationPeer.AppBarToggleButtonAutomationPeer(Microsoft.UI.Xaml.Controls.AppBarToggleButton)
	}
}
