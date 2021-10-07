using System;
using System.Collections.Generic;
using System.Globalization;
using Windows.Foundation;
using Microsoft.UI.Xaml.Documents;
using Uno.Extensions;
using System.Linq;
using Microsoft.UI.Xaml.Hosting;
using SkiaSharp;
using Microsoft.UI.Composition;
using System.Numerics;
using Microsoft.UI.Composition.Interactions;
using Uno.Disposables;
using Microsoft.UI.Xaml.Media;
using Uno.UI;

namespace Microsoft.UI.Xaml.Controls
{
	partial class TextBlock : FrameworkElement
	{
		private readonly TextVisual _textVisual;
		private readonly SerialDisposable _foregroundColorChanged = new SerialDisposable();
		private readonly SerialDisposable _foregroundOpacityChanged = new SerialDisposable();

		public Size _lastMeasure;
		private Size _lastDesiredSize;

		public TextBlock()
		{
			_textVisual = new TextVisual(Visual.Compositor, this);

			Visual.Children.InsertAtBottom(_textVisual);
		}

		private int GetCharacterIndexAtPoint(Point point)
		{
			throw new NotSupportedException();
		}

		partial void OnForegroundChangedPartial()
		{
			var colorBrush = Foreground as SolidColorBrush;

			if (colorBrush != null)
			{
				_foregroundColorChanged.Disposable = colorBrush.RegisterDisposablePropertyChangedCallback(
					SolidColorBrush.ColorProperty,
					(s, colorArg) => _textVisual.UpdateForeground()
				);
				_foregroundOpacityChanged.Disposable = colorBrush.RegisterDisposablePropertyChangedCallback(
					SolidColorBrush.OpacityProperty,
					(s, _) => _textVisual.UpdateForeground()
				);
			}
			else
			{
				_foregroundColorChanged.Disposable = null;
				_foregroundOpacityChanged.Disposable = null;
			}

			_textVisual.UpdateForeground();
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			_lastMeasure = availableSize;
			var padding = Padding;

			// available size considering padding
			var availableSizeWithoutPadding = availableSize.Subtract(Padding);

			var desiredSize = _textVisual.Measure(availableSizeWithoutPadding);

			_lastDesiredSize = desiredSize.Add(padding);

			return new Size(_lastDesiredSize.Width, _lastDesiredSize.Height);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			if (_lastDesiredSize != finalSize)
			{
				_lastMeasure = finalSize;
				_lastDesiredSize = _textVisual.Measure(finalSize);
			}

			_textVisual.Size = new Vector2((float)_lastDesiredSize.Width, (float)_lastDesiredSize.Height);

			return base.ArrangeOverride(finalSize);
		}
	}
}
