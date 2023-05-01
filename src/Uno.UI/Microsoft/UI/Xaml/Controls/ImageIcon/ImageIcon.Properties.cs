﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;

namespace Microsoft/* UWP don't rename */.UI.Xaml.Controls
{
	public partial class ImageIcon
	{
		public ImageSource Source
		{
			get => (ImageSource)GetValue(SourceProperty);
			set => SetValue(SourceProperty, value);
		}

		public static DependencyProperty SourceProperty { get; } =
			DependencyProperty.Register(nameof(Source), typeof(ImageSource), typeof(ImageIcon), new FrameworkPropertyMetadata(null, OnSourcePropertyChanged));


		private static void OnSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
		{
			var owner = sender as ImageIcon;
			owner?.OnSourcePropertyChanged(args);
		}
	}
}
