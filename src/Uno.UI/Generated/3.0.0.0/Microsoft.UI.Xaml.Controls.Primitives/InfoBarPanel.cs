#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls.Primitives
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class InfoBarPanel : global::Microsoft.UI.Xaml.Controls.Panel
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Thickness VerticalOrientationPadding
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Thickness)this.GetValue(VerticalOrientationPaddingProperty);
			}
			set
			{
				this.SetValue(VerticalOrientationPaddingProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Thickness HorizontalOrientationPadding
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Thickness)this.GetValue(HorizontalOrientationPaddingProperty);
			}
			set
			{
				this.SetValue(HorizontalOrientationPaddingProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty HorizontalOrientationMarginProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
			"HorizontalOrientationMargin", typeof(global::Microsoft.UI.Xaml.Thickness), 
			typeof(global::Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Thickness)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty HorizontalOrientationPaddingProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(HorizontalOrientationPadding), typeof(global::Microsoft.UI.Xaml.Thickness), 
			typeof(global::Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Thickness)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty VerticalOrientationMarginProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.RegisterAttached(
			"VerticalOrientationMargin", typeof(global::Microsoft.UI.Xaml.Thickness), 
			typeof(global::Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Thickness)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty VerticalOrientationPaddingProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(VerticalOrientationPadding), typeof(global::Microsoft.UI.Xaml.Thickness), 
			typeof(global::Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Thickness)));
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public InfoBarPanel() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel", "InfoBarPanel.InfoBarPanel()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.InfoBarPanel()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.HorizontalOrientationPadding.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.HorizontalOrientationPadding.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.VerticalOrientationPadding.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.VerticalOrientationPadding.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.HorizontalOrientationPaddingProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.VerticalOrientationPaddingProperty.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static void SetHorizontalOrientationMargin( global::Microsoft.UI.Xaml.DependencyObject @object,  global::Microsoft.UI.Xaml.Thickness value)
		{
			@object.SetValue(HorizontalOrientationMarginProperty, value);
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.Thickness GetHorizontalOrientationMargin( global::Microsoft.UI.Xaml.DependencyObject @object)
		{
			return (global::Microsoft.UI.Xaml.Thickness)@object.GetValue(HorizontalOrientationMarginProperty);
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.HorizontalOrientationMarginProperty.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static void SetVerticalOrientationMargin( global::Microsoft.UI.Xaml.DependencyObject @object,  global::Microsoft.UI.Xaml.Thickness value)
		{
			@object.SetValue(VerticalOrientationMarginProperty, value);
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.Thickness GetVerticalOrientationMargin( global::Microsoft.UI.Xaml.DependencyObject @object)
		{
			return (global::Microsoft.UI.Xaml.Thickness)@object.GetValue(VerticalOrientationMarginProperty);
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Primitives.InfoBarPanel.VerticalOrientationMarginProperty.get
	}
}
