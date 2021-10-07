#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class DynamicOverflowItemsChangingEventArgs 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Controls.CommandBarDynamicOverflowAction Action
		{
			get
			{
				throw new global::System.NotImplementedException("The member CommandBarDynamicOverflowAction DynamicOverflowItemsChangingEventArgs.Action is not implemented in Uno.");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public DynamicOverflowItemsChangingEventArgs() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.DynamicOverflowItemsChangingEventArgs", "DynamicOverflowItemsChangingEventArgs.DynamicOverflowItemsChangingEventArgs()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.DynamicOverflowItemsChangingEventArgs.DynamicOverflowItemsChangingEventArgs()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.DynamicOverflowItemsChangingEventArgs.Action.get
	}
}
