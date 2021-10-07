#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class RefreshVisualizer : global::Microsoft.UI.Xaml.Controls.Control
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Controls.RefreshVisualizerOrientation Orientation
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.RefreshVisualizerOrientation)this.GetValue(OrientationProperty);
			}
			set
			{
				this.SetValue(OrientationProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.UIElement Content
		{
			get
			{
				return (global::Microsoft.UI.Xaml.UIElement)this.GetValue(ContentProperty);
			}
			set
			{
				this.SetValue(ContentProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Controls.RefreshVisualizerState State
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.RefreshVisualizerState)this.GetValue(StateProperty);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty ContentProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Content), typeof(global::Microsoft.UI.Xaml.UIElement), 
			typeof(global::Microsoft.UI.Xaml.Controls.RefreshVisualizer), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.UIElement)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		// Generating stub InfoProviderProperty which has no C# getter
		internal static object InfoProviderProperty { get; }
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty OrientationProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Orientation), typeof(global::Microsoft.UI.Xaml.Controls.RefreshVisualizerOrientation), 
			typeof(global::Microsoft.UI.Xaml.Controls.RefreshVisualizer), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Controls.RefreshVisualizerOrientation)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty StateProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(State), typeof(global::Microsoft.UI.Xaml.Controls.RefreshVisualizerState), 
			typeof(global::Microsoft.UI.Xaml.Controls.RefreshVisualizer), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Controls.RefreshVisualizerState)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public RefreshVisualizer() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "RefreshVisualizer.RefreshVisualizer()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.RefreshVisualizer()
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void RequestRefresh()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "void RefreshVisualizer.RequestRefresh()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.Orientation.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.Orientation.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.Content.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.Content.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.State.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.RefreshRequested.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.RefreshRequested.remove
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.RefreshStateChanged.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.RefreshStateChanged.remove
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.InfoProviderProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.OrientationProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.ContentProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.RefreshVisualizer.StateProperty.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Xaml.Controls.RefreshVisualizer, global::Microsoft.UI.Xaml.Controls.RefreshRequestedEventArgs> RefreshRequested
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshRequestedEventArgs> RefreshVisualizer.RefreshRequested");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshRequestedEventArgs> RefreshVisualizer.RefreshRequested");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Xaml.Controls.RefreshVisualizer, global::Microsoft.UI.Xaml.Controls.RefreshStateChangedEventArgs> RefreshStateChanged
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> RefreshVisualizer.RefreshStateChanged");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.RefreshVisualizer", "event TypedEventHandler<RefreshVisualizer, RefreshStateChangedEventArgs> RefreshVisualizer.RefreshStateChanged");
			}
		}
		#endif
	}
}
