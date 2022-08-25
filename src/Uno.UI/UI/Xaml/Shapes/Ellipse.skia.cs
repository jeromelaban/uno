using Windows.Foundation;
using Uno.Extensions;
using Windows.UI.Composition;
using System.Numerics;
using SkiaSharp;

namespace Windows.UI.Xaml.Shapes
{
	partial class Ellipse : Shape
	{
		private ShapeVisual _rectangleVisual;

		static Ellipse()
		{
			StretchProperty.OverrideMetadata(typeof(Ellipse), new FrameworkPropertyMetadata(defaultValue: Media.Stretch.Fill));
		}

		public Ellipse()
		{
			_rectangleVisual = Visual.Compositor.CreateShapeVisual();
			Visual.Children.InsertAtBottom(_rectangleVisual);
		}

		protected override Size MeasureOverride(Size availableSize)
			=> base.MeasureRelativeShape(availableSize);

		protected override Size ArrangeOverride(Size finalSize)
		{
			var (shapeSize, renderingArea) = ArrangeRelativeShape(finalSize);

			Render(renderingArea.Width > 0 && renderingArea.Height > 0
				? GetGeometry(renderingArea)
				: null);

			return shapeSize;
		}

		private SkiaGeometrySource2D GetGeometry(Rect renderingArea)
		{
			var strokeThickness = (float)StrokeThickness;
			var halpStrokeThickness = strokeThickness / 2;

			var geometry = new SkiaGeometrySource2D();
			var rect = new SKRect(
				(float)renderingArea.X + halpStrokeThickness,
				(float)renderingArea.Y + halpStrokeThickness,
				(float)renderingArea.Right,
				(float)renderingArea.Bottom);
			geometry.Geometry.AddOval(rect);

			return geometry;
		}
	}
}
