using System;
using System.IO;
using SkiaSharp;
using Uno.Extensions;
using Uno.UI.Xaml.Core;
using Windows.UI.Xaml.Input;
using WUX = Windows.UI.Xaml;
using Uno.Foundation.Logging;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Uno.UI.Runtime.Skia.Helpers.Windows;
using Uno.UI.Runtime.Skia.Helpers.Dpi;
using Windows.Graphics.Display;
using Gdk;
using System.Reflection;
using Gtk;
using Silk.NET.OpenGL;

namespace Uno.UI.Runtime.Skia
{
	internal class UnoGLDrawingArea : Gtk.GLArea
	{
		private readonly DisplayInformation _displayInformation;
		private FocusManager _focusManager;
		private SKBitmap bitmap;
		private int renderCount;

		private float? _dpi = 1;
		private GRContext _grContext;
		private GL _gl;

		public UnoGLDrawingArea()
		{
			_displayInformation = DisplayInformation.GetForCurrentView();
			_displayInformation.DpiChanged += OnDpiChanged;
			WUX.Window.InvalidateRender
				+= () =>
				{
					// TODO Uno: Make this invalidation less often if possible.
					//InvalidateOverlays();
					//Invalidate();
					QueueRender();
				};


			SetSizeRequest(300, 300);

			// Set some event handlers
			Realized += OnRealized;
			// Unrealized += OnUnrealized;
			ConfigureEvent += OnConfigure;
			Render += UnoGLDrawingArea_Render;

			// SetRequiredVersion(3, 3);

			HasDepthBuffer = false;
			HasStencilBuffer = false;

			AutoRender = true;

			AttachBuffers();

			_gl = new GL(new Silk.NET.Core.Contexts.DefaultNativeContext("opengl32.dll"));
		}

		private void UnoGLDrawingArea_Render(object o, RenderArgs args)
		{
			args.Context.MakeCurrent();

			// create the contexts if not done already
			if (_grContext == null)
			{
				var glInterface = GRGlInterface.Create();
				_grContext = GRContext.CreateGl(glInterface);
			}

			_gl.Clear(ClearBufferMask.ColorBufferBit);
			_gl.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
			_gl.Flush();

			//var vendor = GL.GetStringS(StringName.Vendor, 0);

			//GL.GetInteger(GetPName.FramebufferBinding, out var framebuffer);
		}

		private void OnConfigure(object o, ConfigureEventArgs args)
		{
			// MakeCurrent();

		}

		private static readonly OpenTK.Windowing.GraphicsLibraryFramework.GLFWCallbacks.ErrorCallback ErrorCallback =
			(errorCode, description) => throw new Exception(description);

		void OnRealized(object o, EventArgs e)
		{
			Context.MakeCurrent();

			// create the contexts if not done already
			if (_grContext == null)
			{
				var glInterface = GRGlInterface.Create();
				_grContext = GRContext.CreateGl(glInterface);
			}

			_gl.Clear(ClearBufferMask.ColorBufferBit);
			_gl.ClearColor(1.0f, 0.0f, 0.0f, 1.0f);
			_gl.Flush();
			// var vendor = _gl.GetStringS(StringName.Vendor, 0);

			//GL.GetInteger(GetPName.DrawFramebufferBinding, out var framebuffer);
		}


		private void OnDpiChanged(DisplayInformation sender, object args) =>
			UpdateDpi();

		private void InvalidateOverlays()
		{
			_focusManager ??= VisualTree.GetFocusManagerForElement(Windows.UI.Xaml.Window.Current?.RootElement);
			_focusManager?.FocusRectManager?.RedrawFocusVisual();
			if (_focusManager?.FocusedElement is TextBox textBox)
			{
				textBox.TextBoxView?.Extension?.InvalidateLayout();
			}
		}

		private void Invalidate()
			=> QueueDrawArea(0, 0, 10000, 10000);

		//protected override bool OnDrawn(Cairo.Context cr)
		//{
		//	int width, height;

		//	if (this.Log().IsEnabled(LogLevel.Trace))
		//	{
		//		this.Log().Trace($"Render {renderCount++}");
		//	}

		//	if (_dpi == null)
		//	{
		//		UpdateDpi();
		//	}
			
		//	width = (int)AllocatedWidth;
		//	height = (int)AllocatedHeight;

		//	var scaledWidth = (int)(width * _dpi.Value);
		//	var scaledHeight = (int)(height * _dpi.Value);

		//	var info = new SKImageInfo(scaledWidth, scaledHeight, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

		//	// reset the bitmap if the size has changed
		//	if (bitmap == null || info.Width != bitmap.Width || info.Height != bitmap.Height)
		//	{
		//		bitmap = new SKBitmap(scaledWidth, scaledHeight, SKColorType.Rgba8888, SKAlphaType.Premul);
		//	}

		//	using (var surface = SKSurface.Create(info, bitmap.GetPixels(out _)))
		//	{
		//		surface.Canvas.Clear(SKColors.White);

		//		surface.Canvas.Scale((float)_dpi);

		//		WUX.Window.Current.Compositor.Render(surface, info);

		//		using (var gtkSurface = new Cairo.ImageSurface(
		//			bitmap.GetPixels(out _),
		//			Cairo.Format.Argb32,
		//			bitmap.Width, bitmap.Height,
		//			bitmap.Width * 4))
		//		{
		//			gtkSurface.MarkDirty();
		//			cr.Scale(1 / _dpi.Value, 1 / _dpi.Value);
		//			cr.SetSourceSurface(gtkSurface, 0, 0);
		//			cr.Paint();
		//		}
		//	}

		//	return true;
		//}

		internal void TakeScreenshot(string filePath)
		{
			using Stream memStream = File.Open(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
			using SKManagedWStream wstream = new SKManagedWStream(memStream);

			bitmap.Encode(wstream, SKEncodedImageFormat.Png, 100);
		}

		private void UpdateDpi() => _dpi = (float)_displayInformation.RawPixelsPerViewPixel;
	}
}
