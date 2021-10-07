#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Media.Animation
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class ColorAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		// Skipping already declared property To
		// Skipping already declared property From
		// Skipping already declared property EnableDependentAnimation
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Media.Animation.EasingFunctionBase EasingFunction
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Media.Animation.EasingFunctionBase)this.GetValue(EasingFunctionProperty);
			}
			set
			{
				this.SetValue(EasingFunctionProperty, value);
			}
		}
		#endif
		// Skipping already declared property By
		// Skipping already declared property ByProperty
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty EasingFunctionProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(EasingFunction), typeof(global::Microsoft.UI.Xaml.Media.Animation.EasingFunctionBase), 
			typeof(global::Microsoft.UI.Xaml.Media.Animation.ColorAnimation), 
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Media.Animation.EasingFunctionBase)));
		#endif
		// Skipping already declared property EnableDependentAnimationProperty
		// Skipping already declared property FromProperty
		// Skipping already declared property ToProperty
		// Skipping already declared method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.ColorAnimation()
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.ColorAnimation()
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.From.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.From.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.To.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.To.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.By.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.By.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EasingFunction.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EasingFunction.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EnableDependentAnimation.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EnableDependentAnimation.set
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.FromProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.ToProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.ByProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EasingFunctionProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Media.Animation.ColorAnimation.EnableDependentAnimationProperty.get
	}
}
