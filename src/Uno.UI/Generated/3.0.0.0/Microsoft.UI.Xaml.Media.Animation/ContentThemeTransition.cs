#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Media.Animation
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ContentThemeTransition : global::Microsoft.UI.Xaml.Media.Animation.Transition
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  double VerticalOffset
		{
			get
			{
				return (double)this.GetValue(VerticalOffsetProperty);
			}
			set
			{
				this.SetValue(VerticalOffsetProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  double HorizontalOffset
		{
			get
			{
				return (double)this.GetValue(HorizontalOffsetProperty);
			}
			set
			{
				this.SetValue(HorizontalOffsetProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty HorizontalOffsetProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(HorizontalOffset), typeof(double), 
			typeof(global::Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(double)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty VerticalOffsetProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(VerticalOffset), typeof(double), 
			typeof(global::Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(double)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public ContentThemeTransition() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition", "ContentThemeTransition.ContentThemeTransition()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.ContentThemeTransition()
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.HorizontalOffset.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.HorizontalOffset.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.VerticalOffset.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.VerticalOffset.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.HorizontalOffsetProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ContentThemeTransition.VerticalOffsetProperty.get
	}
}
