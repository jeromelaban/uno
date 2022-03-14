#nullable enable

using System;
using System.Diagnostics;
using System.Windows.Controls;
using SharpGL;
using SharpGL.WPF;
using Silk.NET.Core.Loader;
using Silk.NET.OpenGL;
using SkiaSharp;
using Uno.UI.Skia.Platform;
using Windows.Graphics.Display;
using WUX = Windows.UI.Xaml;

namespace Uno.UI.Runtime.Skia.Wpf
{
	internal class GLRenderSurface : Border, IRenderSurface
	{
		private const SKColorType colorType = SKColorType.Rgba8888;
		private const GRSurfaceOrigin surfaceOrigin = GRSurfaceOrigin.BottomLeft;

		private readonly WpfHost _wpfHost;
		private readonly DisplayInformation _displayInformation;
		private readonly OpenGLControl _glControl;

		private GRContext? _grContext;
		private GRBackendRenderTarget? _renderTarget;
		private SKSurface? _surface;
		private GL _gl;

		public GLRenderSurface(WpfHost wpfHost)
		{
			_wpfHost = wpfHost;
			_displayInformation = DisplayInformation.GetForCurrentView();

			Child = _glControl = new SharpGL.WPF.OpenGLControl();
			_glControl.OpenGLDraw += _glControl_OpenGLDraw;

			_glControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL4_4;
			_glControl.RenderContextType = RenderContextType.FBO;

			_gl = new GL(new Silk.NET.Core.Contexts.DefaultNativeContext(new GLCoreLibraryNameContainer().GetLibraryName()));
		}

		private void _glControl_OpenGLDraw(object sender, OpenGLRoutedEventArgs args)
		{
			var sw = Stopwatch.StartNew();

			var gl = args.OpenGL;

			// create the contexts if not done already
			if (_grContext == null)
			{
				var glInterface = GRGlInterface.Create();
				_grContext = GRContext.CreateGl(glInterface);
			}

			gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
			gl.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);

			// manage the drawing surface
			var res = 1; // _displayInformation.RawPixelsPerViewPixel;
			var w = Math.Max(0, (int)(gl.RenderContextProvider.Width * res));
			var h = Math.Max(0, (int)(gl.RenderContextProvider.Height * res));

			if (_renderTarget == null || _surface == null || _renderTarget.Width != w || _renderTarget.Height != h)
			{
				// create or update the dimensions
				_renderTarget?.Dispose();

				var values = new int[4];
				gl.GetInteger(OpenGL.GL_FRAMEBUFFER_BINDING_EXT, values);
				var framebuffer = values[0];

				gl.GetInteger(OpenGL.GL_STENCIL, values);
				var stencil = values[0];

				gl.GetInteger(OpenGL.GL_SAMPLES, values);
				var samples = values[0];

				var maxSamples = _grContext.GetMaxSurfaceSampleCount(colorType);

				if (samples > maxSamples)
				{
					samples = maxSamples;
				}

				var glInfo = new GRGlFramebufferInfo((uint)framebuffer, colorType.ToGlSizedFormat());

				_renderTarget = new GRBackendRenderTarget(w, h, samples, stencil, glInfo);

				// create the surface
				_surface?.Dispose();
				_surface = SKSurface.Create(_grContext, _renderTarget, surfaceOrigin, colorType);
			}

			using (new SKAutoCanvasRestore(_surface.Canvas, true))
			{
				_surface.Canvas.Clear(SKColors.White);

				// _surface.Canvas.Scale((float)(1/_dpi));

				WUX.Window.Current.Compositor.Render(_surface);
			}

			// update the control
			_surface.Canvas.Flush();

			gl.Flush();
			sw.Stop();
		}

		public void Refresh()
		{
			_glControl.DoRender();
		}

		// Extracted from https://github.com/dotnet/Silk.NET/blob/23f9bd4d67ad21c69fbd69cc38a62fb2c0ec3927/src/OpenGL/Silk.NET.OpenGL/GLCoreLibraryNameContainer.cs
		internal class GLCoreLibraryNameContainer : SearchPathContainer
		{
			/// <inheritdoc />
			public override string Linux => "libGL.so.1";

			/// <inheritdoc />
			public override string MacOS => "/System/Library/Frameworks/OpenGL.framework/OpenGL";

			/// <inheritdoc />
			public override string Android => "libGL.so.1";

			/// <inheritdoc />
			public override string IOS => "/System/Library/Frameworks/OpenGL.framework/OpenGL";

			/// <inheritdoc />
			public override string Windows64 => "opengl32.dll";

			/// <inheritdoc />
			public override string Windows86 => "opengl32.dll";
		}

	}
}
