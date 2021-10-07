#if HAS_UNO_WINUI
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.UI.Xaml.Media.Animation
{
	[global::Uno.NotImplemented]
	internal partial class PointerUpThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.PointerUpThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public PointerUpThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Media.Animation.PointerUpThemeAnimation", "PointerUpThemeAnimation.PointerUpThemeAnimation()");
		}
	}

	[global::Uno.NotImplemented]
	internal partial class PointerDownThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.PointerDownThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public PointerDownThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Media.Animation.PointerDownThemeAnimation", "PointerDownThemeAnimation.PointerDownThemeAnimation()");
		}
	}

	[global::Uno.NotImplemented]
	internal partial class DragOverThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public double ToOffset
		{
			get
			{
				return (double)this.GetValue(ToOffsetProperty);
			}
			set
			{
				this.SetValue(ToOffsetProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::Microsoft.UI.Xaml.Controls.Primitives.AnimationDirection Direction
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Primitives.AnimationDirection)this.GetValue(DirectionProperty);
			}
			set
			{
				this.SetValue(DirectionProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty DirectionProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(Direction), typeof(global::Microsoft.UI.Xaml.Controls.Primitives.AnimationDirection),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.DragOverThemeAnimation),
			new FrameworkPropertyMetadata(default(global::Microsoft.UI.Xaml.Controls.Primitives.AnimationDirection)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.DragOverThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty ToOffsetProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(ToOffset), typeof(double),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.DragOverThemeAnimation),
			new FrameworkPropertyMetadata(default(double)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public DragOverThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Xaml.Media.Animation.DragOverThemeAnimation", "DragOverThemeAnimation.DragOverThemeAnimation()");
		}
	}

	[global::Uno.NotImplemented]
	internal partial class DragItemThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.DragItemThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public DragItemThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.DragItemThemeAnimation", "DragItemThemeAnimation.DragItemThemeAnimation()");
		}
	}

	[global::Uno.NotImplemented]

	internal partial class DropTargetItemThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.DropTargetItemThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public DropTargetItemThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.DropTargetItemThemeAnimation", "DropTargetItemThemeAnimation.DropTargetItemThemeAnimation()");
		}
	}

	[global::Uno.NotImplemented]
	internal partial class RepositionThemeAnimation : global::Microsoft.UI.Xaml.Media.Animation.Timeline
	{
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public string TargetName
		{
			get
			{
				return (string)this.GetValue(TargetNameProperty);
			}
			set
			{
				this.SetValue(TargetNameProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public double FromVerticalOffset
		{
			get
			{
				return (double)this.GetValue(FromVerticalOffsetProperty);
			}
			set
			{
				this.SetValue(FromVerticalOffsetProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public double FromHorizontalOffset
		{
			get
			{
				return (double)this.GetValue(FromHorizontalOffsetProperty);
			}
			set
			{
				this.SetValue(FromHorizontalOffsetProperty, value);
			}
		}

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty FromHorizontalOffsetProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(FromHorizontalOffset), typeof(double),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.RepositionThemeAnimation),
			new FrameworkPropertyMetadata(default(double)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty FromVerticalOffsetProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(FromVerticalOffset), typeof(double),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.RepositionThemeAnimation),
			new FrameworkPropertyMetadata(default(double)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.DependencyProperty TargetNameProperty { get; } =
		Microsoft.UI.Xaml.DependencyProperty.Register(
			nameof(TargetName), typeof(string),
			typeof(global::Microsoft.UI.Xaml.Media.Animation.RepositionThemeAnimation),
			new FrameworkPropertyMetadata(default(string)));

		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public RepositionThemeAnimation() : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Media.Animation.RepositionThemeAnimation", "RepositionThemeAnimation.RepositionThemeAnimation()");
		}
	}
}

namespace Microsoft.UI.Xaml.Controls.Primitives
{
	[global::Uno.NotImplemented]
	internal enum AnimationDirection
	{
		Left,
		Top,
		Right,
		Bottom,
	}
}
#endif
