#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
	#if false || false || false || false || false || false || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class AppBarButton : global::Microsoft.UI.Xaml.Controls.Button,global::Microsoft.UI.Xaml.Controls.ICommandBarElement
	{
		// Skipping already declared property LabelPosition
		// Skipping already declared property Label
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string KeyboardAcceleratorTextOverride
		{
			get
			{
				return (string)this.GetValue(KeyboardAcceleratorTextOverrideProperty);
			}
			set
			{
				this.SetValue(KeyboardAcceleratorTextOverrideProperty, value);
			}
		}
		#endif
		// Skipping already declared property Icon
		// Skipping already declared property TemplateSettings
		// Skipping already declared property IsCompact
		// Skipping already declared property DynamicOverflowOrder
		// Skipping already declared property IsInOverflow
		// Skipping already declared property DynamicOverflowOrderProperty
		// Skipping already declared property IconProperty
		// Skipping already declared property IsCompactProperty
		// Skipping already declared property IsInOverflowProperty
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty KeyboardAcceleratorTextOverrideProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(KeyboardAcceleratorTextOverride), typeof(string), 
			typeof(global::Microsoft.UI.Xaml.Controls.AppBarButton), 
			new FrameworkPropertyMetadata(default(string)));
		#endif
		// Skipping already declared property LabelPositionProperty
		// Skipping already declared property LabelProperty
		// Skipping already declared method Microsoft.UI.Xaml.Controls.AppBarButton.AppBarButton()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.AppBarButton()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.Label.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.Label.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.Icon.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.Icon.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.LabelPosition.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.LabelPosition.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.KeyboardAcceleratorTextOverride.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.KeyboardAcceleratorTextOverride.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.TemplateSettings.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IsCompact.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IsCompact.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IsInOverflow.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.DynamicOverflowOrder.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.DynamicOverflowOrder.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.LabelProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IconProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.LabelPositionProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.KeyboardAcceleratorTextOverrideProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IsCompactProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.IsInOverflowProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.AppBarButton.DynamicOverflowOrderProperty.get
		// Processing: Microsoft.UI.Xaml.Controls.ICommandBarElement
	}
}
