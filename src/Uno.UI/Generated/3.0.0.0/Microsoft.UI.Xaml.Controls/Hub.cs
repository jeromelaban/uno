#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class Hub : global::Microsoft.UI.Xaml.Controls.Control,global::Microsoft.UI.Xaml.Controls.ISemanticZoomInformation
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Controls.Orientation Orientation
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Orientation)this.GetValue(OrientationProperty);
			}
			set
			{
				this.SetValue(OrientationProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.DataTemplate HeaderTemplate
		{
			get
			{
				return (global::Microsoft.UI.Xaml.DataTemplate)this.GetValue(HeaderTemplateProperty);
			}
			set
			{
				this.SetValue(HeaderTemplateProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  object Header
		{
			get
			{
				return (object)this.GetValue(HeaderProperty);
			}
			set
			{
				this.SetValue(HeaderProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int DefaultSectionIndex
		{
			get
			{
				return (int)this.GetValue(DefaultSectionIndexProperty);
			}
			set
			{
				this.SetValue(DefaultSectionIndexProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.Collections.IObservableVector<object> SectionHeaders
		{
			get
			{
				throw new global::System.NotImplementedException("The member IObservableVector<object> Hub.SectionHeaders is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IObservableVector%3Cobject%3E%20Hub.SectionHeaders");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.HubSection> Sections
		{
			get
			{
				throw new global::System.NotImplementedException("The member IList<HubSection> Hub.Sections is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IList%3CHubSection%3E%20Hub.Sections");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Collections.Generic.IList<global::Microsoft.UI.Xaml.Controls.HubSection> SectionsInView
		{
			get
			{
				throw new global::System.NotImplementedException("The member IList<HubSection> Hub.SectionsInView is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IList%3CHubSection%3E%20Hub.SectionsInView");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Xaml.Controls.SemanticZoom SemanticZoomOwner
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.SemanticZoom)this.GetValue(SemanticZoomOwnerProperty);
			}
			set
			{
				this.SetValue(SemanticZoomOwnerProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsZoomedInView
		{
			get
			{
				return (bool)this.GetValue(IsZoomedInViewProperty);
			}
			set
			{
				this.SetValue(IsZoomedInViewProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsActiveView
		{
			get
			{
				return (bool)this.GetValue(IsActiveViewProperty);
			}
			set
			{
				this.SetValue(IsActiveViewProperty, value);
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty DefaultSectionIndexProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(DefaultSectionIndex), typeof(int), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(int)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty HeaderProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Header), typeof(object), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(object)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty HeaderTemplateProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(HeaderTemplate), typeof(global::Microsoft.UI.Xaml.DataTemplate), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.DataTemplate)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty IsActiveViewProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(IsActiveView), typeof(bool), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(bool)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty IsZoomedInViewProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(IsZoomedInView), typeof(bool), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(bool)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty OrientationProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Orientation), typeof(global::Microsoft.UI.Xaml.Controls.Orientation), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Controls.Orientation)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty SemanticZoomOwnerProperty { get; } = 
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(SemanticZoomOwner), typeof(global::Microsoft.UI.Xaml.Controls.SemanticZoom), 
			typeof(global::Microsoft.UI.Xaml.Controls.Hub), 
			new Microsoft.UI.Xaml.FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Controls.SemanticZoom)));
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public Hub() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "Hub.Hub()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Hub()
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Header.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Header.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.HeaderTemplate.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.HeaderTemplate.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Orientation.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Orientation.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.DefaultSectionIndex.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.DefaultSectionIndex.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.Sections.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionsInView.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionHeaders.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionHeaderClick.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionHeaderClick.remove
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionsInViewChanged.add
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SectionsInViewChanged.remove
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void ScrollToSection( global::Microsoft.UI.Xaml.Controls.HubSection section)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.ScrollToSection(HubSection section)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SemanticZoomOwner.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SemanticZoomOwner.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsActiveView.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsActiveView.set
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsZoomedInView.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsZoomedInView.set
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void InitializeViewChange()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.InitializeViewChange()");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void CompleteViewChange()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChange()");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void MakeVisible( global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation item)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.MakeVisible(SemanticZoomLocation item)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void StartViewChangeFrom( global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation source,  global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation destination)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.StartViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void StartViewChangeTo( global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation source,  global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation destination)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.StartViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void CompleteViewChangeFrom( global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation source,  global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation destination)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChangeFrom(SemanticZoomLocation source, SemanticZoomLocation destination)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void CompleteViewChangeTo( global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation source,  global::Microsoft.UI.Xaml.Controls.SemanticZoomLocation destination)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "void Hub.CompleteViewChangeTo(SemanticZoomLocation source, SemanticZoomLocation destination)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.HeaderProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.HeaderTemplateProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.OrientationProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.DefaultSectionIndexProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.SemanticZoomOwnerProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsActiveViewProperty.get
		// Forced skipping of method Microsoft.UI.Xaml.Controls.Hub.IsZoomedInViewProperty.get
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Microsoft.UI.Xaml.Controls.HubSectionHeaderClickEventHandler SectionHeaderClick
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "event HubSectionHeaderClickEventHandler Hub.SectionHeaderClick");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "event HubSectionHeaderClickEventHandler Hub.SectionHeaderClick");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Microsoft.UI.Xaml.Controls.SectionsInViewChangedEventHandler SectionsInViewChanged
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "event SectionsInViewChangedEventHandler Hub.SectionsInViewChanged");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Controls.Hub", "event SectionsInViewChangedEventHandler Hub.SectionsInViewChanged");
			}
		}
		#endif
		// Processing: Microsoft.UI.Xaml.Controls.ISemanticZoomInformation
	}
}
