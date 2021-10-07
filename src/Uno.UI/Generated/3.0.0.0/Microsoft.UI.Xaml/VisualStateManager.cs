#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class VisualStateManager : global::Microsoft.UI.Xaml.DependencyObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty CustomVisualStateManagerProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
			"CustomVisualStateManager", typeof(global::Microsoft.UI.Xaml.VisualStateManager), 
			typeof(global::Microsoft.UI.Xaml.VisualStateManager), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.VisualStateManager)));
		#endif
		// Skipping already declared method Microsoft.UI.Xaml.VisualStateManager.VisualStateManager()
		// Forced skipping of method Microsoft.UI.Xaml.VisualStateManager.VisualStateManager()
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		protected  void RaiseCurrentStateChanging( global::Microsoft.UI.Xaml.VisualStateGroup stateGroup,  global::Microsoft.UI.Xaml.VisualState oldState,  global::Microsoft.UI.Xaml.VisualState newState,  global::Microsoft.UI.Xaml.Controls.Control control)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.VisualStateManager", "void VisualStateManager.RaiseCurrentStateChanging(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		protected  void RaiseCurrentStateChanged( global::Microsoft.UI.Xaml.VisualStateGroup stateGroup,  global::Microsoft.UI.Xaml.VisualState oldState,  global::Microsoft.UI.Xaml.VisualState newState,  global::Microsoft.UI.Xaml.Controls.Control control)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.VisualStateManager", "void VisualStateManager.RaiseCurrentStateChanged(VisualStateGroup stateGroup, VisualState oldState, VisualState newState, Control control)");
		}
		#endif
		// Skipping already declared method Microsoft.UI.Xaml.VisualStateManager.GoToStateCore(Microsoft.UI.Xaml.Controls.Control, Microsoft.UI.Xaml.FrameworkElement, string, Microsoft.UI.Xaml.VisualStateGroup, Microsoft.UI.Xaml.VisualState, bool)
		// Skipping already declared method Microsoft.UI.Xaml.VisualStateManager.GetVisualStateGroups(Microsoft.UI.Xaml.FrameworkElement)
		// Forced skipping of method Microsoft.UI.Xaml.VisualStateManager.CustomVisualStateManagerProperty.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.VisualStateManager GetCustomVisualStateManager( global::Microsoft.UI.Xaml.FrameworkElement obj)
		{
			return (global::Microsoft.UI.Xaml.VisualStateManager)obj.GetValue(CustomVisualStateManagerProperty);
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static void SetCustomVisualStateManager( global::Microsoft.UI.Xaml.FrameworkElement obj,  global::Microsoft.UI.Xaml.VisualStateManager value)
		{
			obj.SetValue(CustomVisualStateManagerProperty, value);
		}
		#endif
		// Skipping already declared method Microsoft.UI.Xaml.VisualStateManager.GoToState(Microsoft.UI.Xaml.Controls.Control, string, bool)
	}
}
