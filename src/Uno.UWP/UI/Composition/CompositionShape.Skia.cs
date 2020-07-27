using SkiaSharp;
using System;
using System.Numerics;

namespace Windows.UI.Composition
{
	public  partial class CompositionShape
	{
		internal CompositionShape() => throw new InvalidOperationException($"Use the ctor with Compositor");

		internal CompositionShape(Compositor compositor) : base(compositor)
		{
		}

		internal virtual void Render(SKSurface surface, SKImageInfo info)
		{

		}
	}
}
