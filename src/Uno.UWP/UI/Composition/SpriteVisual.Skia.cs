using System;
using System.Collections.Generic;
using System.Numerics;
using SkiaSharp;
using Uno.Disposables;
using Uno.Extensions;
using Uno.Logging;

namespace Windows.UI.Composition
{
	public partial class SpriteVisual : ContainerVisual
	{
		private SerialDisposable _csbSubscription = new SerialDisposable();

		private readonly SKPaint _paint
			= new SKPaint()
			{
				IsAntialias = true,
			};

		partial void OnBrushChangedPartial(CompositionBrush brush)
		{
			_csbSubscription.Disposable = null;

			if (brush is CompositionSurfaceBrush csb)
			{
				csb.PropertyChanged += UpdatePaint;
				_csbSubscription.Disposable = Disposable.Create(() => csb.PropertyChanged -= UpdatePaint);
			}

			UpdatePaint();
		}

		private void UpdatePaint()
		{
			if (Brush is CompositionColorBrush b)
			{
				_paint.Color = new SKColor(b.Color.R, b.Color.G, b.Color.B, b.Color.A);
			}
			else if (Brush is CompositionSurfaceBrush csb)
			{
				if (csb.Surface is SkiaCompositionSurface scs)
				{
					_paint.Shader = SKShader.CreateImage(scs.Image, SKShaderTileMode.Repeat, SKShaderTileMode.Repeat, csb.TransformMatrix.ToSKMatrix());
					_paint.IsAntialias = true;
				}
			}
			else
			{
				this.Log().Error($"The brush type {Brush?.GetType()} is not supported for sprite visuals.");
			}
		}

		internal override void Render(SKSurface surface, SKImageInfo info)
		{
			base.Render(surface, info);

			surface.Canvas.Save();

			surface.Canvas.DrawRect(
				new SKRect(left: 0, top: 0, right: Size.X, bottom: Size.Y),
				_paint
			);

			surface.Canvas.Restore();
		}
	}
}
