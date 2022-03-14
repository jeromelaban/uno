#nullable enable

using System;
using Gdk;
using Gtk;
using Silk.NET.Core.Loader;
using Silk.NET.OpenGL;
using Uno.Foundation.Logging;

namespace Uno.UI.Runtime.Skia
{
	internal class CustomGLArea : Widget
	{
		private GLContext? _context;
		private Gdk.Window? _eventWindow;
		private GL _gl;
		private string? _errorMessage;

		private bool _haveBuffers;

		private int required_gl_version;

		private uint _frameBuffer;
		private uint _renderBuffer;
		private uint _texture;
		private uint _depthStencilBuffer;

		private bool _hasAlpha;
		private bool _hasDepthBuffer;
		private bool _hasStencilBuffer;

		private bool _needsResize;
		private bool _needsRender;
		private bool _autoRender;
		private bool _useES;

		public CustomGLArea()
		{
			MapEvent += (s, e) => gtk_gl_area_map();
			UnmapEvent += (s, e) => gtk_gl_area_unmap();

			HasWindow = false;
			AppPaintable = true;

			_autoRender = true;
			_needsRender = true;
			required_gl_version = 0;

			_gl = new GL(new Silk.NET.Core.Contexts.DefaultNativeContext(new GLCoreLibraryNameContainer().GetLibraryName()));
		}

		private void gtk_gl_area_dispose()
		{
			//GtkGLArea* area = GTK_GL_AREA(gobject);
			//GtkGLAreaPrivate* priv = gtk_gl_area_get_instance_private(area);

			//g_clear_object(&context);

			//G_OBJECT_CLASS(gtk_gl_area_parent_class)->dispose(gobject);
		}

		protected override void OnRealized()
		{
			try
			{
				WindowAttr attributes = new WindowAttr();
				WindowAttributesType attributes_mask;

				base.OnRealized();

				Rectangle allocation = Allocation;

				attributes.WindowType = Gdk.WindowType.Child; // GDK_WINDOW_CHILD;
				attributes.X = allocation.X;
				attributes.Y = allocation.Y;
				attributes.Width = allocation.Width;
				attributes.Height = allocation.Height;
				attributes.Wclass = WindowWindowClass.InputOnly; // GDK_INPUT_ONLY;
				attributes.Mask = Events;

				attributes_mask = WindowAttributesType.X | WindowAttributesType.Y;

				_eventWindow = new Gdk.Window(ParentWindow, attributes, attributes_mask);
				RegisterWindow(_eventWindow);

				_context = CreateContext();
			}
			catch(Exception e)
			{
				_errorMessage = e.ToString();
			}

			_needsResize = true;
		}

		//static void
		//gtk_gl_area_notify (GObject    *object,
		//					GParamSpec *pspec)
		//{
		//  if (strcmp (pspec->name, "scale-factor") == 0)
		//	{
		//	  GtkGLArea *area = GTK_GL_AREA (object);
		//	  GtkGLAreaPrivate *priv = gtk_gl_area_get_instance_private (area);

		//	  needs_resize = true;
		//	}

		//  if (G_OBJECT_CLASS (gtk_gl_area_parent_class)->notify)
		//	G_OBJECT_CLASS (gtk_gl_area_parent_class)->notify (object, pspec);
		//}

		public virtual GLContext CreateContext()
		{
			var context = Window.CreateGlContext();

			context.SetUseEs(_useES ? 1 : 0);
			context.SetRequiredVersion(required_gl_version / 10, required_gl_version % 10);

			context.Realize();

			return context;
		}

		public virtual void OnResize(uint width, uint height)
		{
			_gl.Viewport(0, 0, width, height);
		}

		private unsafe void gtk_gl_area_ensure_buffers()
		{
			Realize();

			if (_context == null)
				return;

			if (_haveBuffers)
				return;

			_haveBuffers = true;

			_frameBuffer = _gl.GenFramebuffer();

			if (_hasAlpha)
			{
				/* For alpha we use textures as that is required for blending to work */
				if (_texture == 0)
				{
					Span<Texture> textures = new Span<Texture>(new Texture[1]);
					_gl.GenTextures(textures);
					_texture = textures[0].Handle;
				}

				/* Delete old render buffer if any */
				if (_renderBuffer != 0)
				{
					fixed (uint* ptr = &_renderBuffer)
					{
						_gl.DeleteRenderbuffers(1, ptr);
					}
					_renderBuffer = 0;
				}
			}
			else
			{
				/* For non-alpha we use render buffers so we can blit instead of texture the result */
				if (_renderBuffer == 0)
				{
					fixed (uint* ptr = &_renderBuffer)
					{
						_gl.GenRenderbuffers(1, ptr);
					}
				}

				/* Delete old texture if any */
				if (_texture != 0)
				{
					fixed (uint* ptr = &_texture)
					{
						_gl.DeleteTextures(1, ptr);
					}
					_texture = 0;
				}
			}

			if ((_hasDepthBuffer || _hasStencilBuffer))
			{
				if (_depthStencilBuffer == 0)
				{
					fixed (uint* ptr = &_depthStencilBuffer)
					{
						_gl.GenRenderbuffers(1, ptr);
					}
				}
			}
			else if (_depthStencilBuffer != 0)
			{
				/* Delete old depth/stencil buffer */
				fixed (uint* ptr = &_depthStencilBuffer)
				{
					_gl.DeleteRenderbuffers(1, ptr);
				}
				_depthStencilBuffer = 0;
			}

			gtk_gl_area_allocate_buffers();
		}

		private unsafe void gtk_gl_area_allocate_buffers()
		{
			int scale, width, height;

			if (_context == null)
				return;

			scale = ScaleFactor;
			width = AllocatedWidth * scale;
			height = AllocatedHeight * scale;

			if (_texture != 0)
			{
				_gl.BindTexture(GLEnum.Texture2D, _texture);
				_gl.TexParameterI(GLEnum.Texture2D, GLEnum.TextureWrapS /*GL_TEXTURE_WRAP_S*/, (uint)GLEnum.Repeat);
				_gl.TexParameterI(GLEnum.Texture2D, GLEnum.TextureWrapT /*GL_TEXTURE_WRAP_T*/, (uint)GLEnum.Repeat);
				_gl.TexParameterI(GLEnum.Texture2D, GLEnum.TextureMinFilter /*GL_TEXTURE_MIN_FILTER*/, (uint)GLEnum.Repeat);
				_gl.TexParameterI(GLEnum.Texture2D, GLEnum.TextureMagFilter /*GL_TEXTURE_MAG_FILTER*/, (uint)GLEnum.Repeat);

				if (_context.UseEs)
					_gl.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgba8, (uint)width, (uint)height, 0, GLEnum.Rgba, GLEnum.UnsignedByte, null);
				else
					_gl.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgba8, (uint)width, (uint)height, 0, GLEnum.Bgra, GLEnum.UnsignedByte, null);
			}

			if (_renderBuffer != 0)
			{
				_gl.BindRenderbuffer(GLEnum.Renderbuffer, _renderBuffer);
				_gl.RenderbufferStorage(GLEnum.Renderbuffer, GLEnum.Rgb8, (uint)width, (uint)height);
			}

			if (_hasDepthBuffer || _hasStencilBuffer)
			{
				_gl.BindRenderbuffer(GLEnum.Renderbuffer, _depthStencilBuffer);
				if (_hasStencilBuffer)
				{
					_gl.RenderbufferStorage(GLEnum.Renderbuffer, GLEnum.Depth24Stencil8 /*DEPTH24_STENCIL8*/, (uint)width, (uint)height);
				}
				else
				{
					_gl.RenderbufferStorage(GLEnum.Renderbuffer, GLEnum.DepthComponent24 /*DEPTH_COMPONENT24*/, (uint)width, (uint)height);
				}
			}

			_needsRender = true;
		}

		private void gtk_gl_area_attach_buffers()
		{
			if (_context == null)
			{
				return;
			}

			MakeCurrent();

			if (!_haveBuffers)
			{
				gtk_gl_area_ensure_buffers();
			}
			else if (_needsResize)
			{
				gtk_gl_area_allocate_buffers();
			}

			_gl.BindFramebuffer(GLEnum.Framebuffer, _frameBuffer);

			if (_texture != 0)
			{
				_gl.FramebufferTexture2D(GLEnum.Framebuffer, GLEnum.ColorAttachment0,
										GLEnum.Texture2D, _texture, 0);
			}
			else if (_renderBuffer != 0)
			{
				_gl.FramebufferRenderbuffer(GLEnum.Framebuffer, GLEnum.ColorAttachment0,
										   GLEnum.Renderbuffer, _renderBuffer);
			}

			if (_depthStencilBuffer != 0)
			{
				if (_hasDepthBuffer)
					_gl.FramebufferRenderbuffer(GLEnum.Framebuffer, GLEnum.DepthAttachment,
											   GLEnum.Renderbuffer, _depthStencilBuffer);
				if (_hasStencilBuffer)
					_gl.FramebufferRenderbuffer(GLEnum.Framebuffer, GLEnum.StencilAttachment,
											   GLEnum.Renderbuffer, _depthStencilBuffer);
			}
		}

		private unsafe void gtk_gl_area_delete_buffers()
		{
			if (_context == null)
			{
				return;
			}

			_haveBuffers = false;

			if (_renderBuffer != 0)
			{
				fixed (uint* ptr = &_renderBuffer)
				{
					_gl.DeleteRenderbuffers(1, ptr);
				}
				_renderBuffer = 0;
			}

			if (_texture != 0)
			{
				fixed (uint* ptr = &_texture)
				{
					_gl.DeleteTextures(1, ptr);
				}
				_texture = 0;
			}

			if (_depthStencilBuffer != 0)
			{
				fixed (uint* ptr = &_depthStencilBuffer)
				{
					_gl.DeleteRenderbuffers(1, ptr);
				}
				_depthStencilBuffer = 0;
			}

			if (_frameBuffer != 0)
			{
				_gl.BindFramebuffer(GLEnum.Framebuffer, 0);
				fixed (uint* ptr = &_frameBuffer)
				{
					_gl.DeleteFramebuffers(1, ptr);
				}
				_frameBuffer = 0;
			}
		}

		protected override void OnUnrealized()
		{
			if (_context != null)
			{
				if (_haveBuffers)
				{
					MakeCurrent();
					gtk_gl_area_delete_buffers();
				}

				/* Make sure to unset the context if current */
				if (_context == GLContext.Current)
				{
					GLContext.ClearCurrent();
				}
			}

			if (_eventWindow != null)
			{
				UnregisterWindow(_eventWindow);
				_eventWindow.Destroy();

				_eventWindow = null;
			}

			base.OnUnrealized();
		}

		private void gtk_gl_area_map()
		{
			if (_eventWindow != null)
			{
				_eventWindow.Show();
			}
		}

		private void gtk_gl_area_unmap()
		{
			if (_eventWindow != null)
			{
				_eventWindow.Hide();
			}
		}

		protected override void OnSizeAllocated(Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);

			if (IsRealized && _eventWindow != null)
			{
				_eventWindow.MoveResize(allocation);

				_needsResize = true;
			}
		}

		private void gtk_gl_area_draw_error_screen(Cairo.Context cr,
									   int width,
									   int height)
		{
			Pango.Layout layout = CreatePangoLayout(_errorMessage);

			layout.Width = (int)(width * Pango.Scale.PangoScale);
			layout.Alignment = Pango.Alignment.Center;
			layout.GetPixelSize(out _, out var layout_height);

			StyleContext.RenderLayout(
							   cr,
							   0, (height - layout_height) / 2,
							   layout);
		}

		protected override bool OnDrawn(Cairo.Context cr)
		{
			int w, h, scale;
			GLEnum status;

			if (_errorMessage != null)
			{
				gtk_gl_area_draw_error_screen(
					cr,
					AllocatedWidth,
					AllocatedHeight);
				return false;
			}

			if (_context == null)
			{
				return false;
			}

			MakeCurrent();

			gtk_gl_area_attach_buffers();

			if (_hasDepthBuffer)
			{
				_gl.Enable(GLEnum.DepthTest);
			}
			else
			{
				_gl.Disable(GLEnum.DepthTest);
			}

			scale = ScaleFactor;
			w = AllocatedWidth * scale;
			h = AllocatedHeight * scale;

			status = _gl.CheckFramebufferStatus(GLEnum.Framebuffer);
			if (status == GLEnum.FramebufferComplete)
			{
				if (_needsRender || _autoRender)
				{
					if (_needsResize)
					{
						OnResize((uint)w, (uint)h);
						_needsResize = false;
					}

					OnRender(_context);
				}

				_needsRender = false;

				Gdk.CairoHelper.DrawFromGl(cr,
										Window,
										(int)(_texture != 0 ? _texture : _renderBuffer),
										(int)(_texture != 0 ? GLEnum.Texture : GLEnum.Renderbuffer),
										scale, 0, 0, w, h);

				MakeCurrent();
			}
			else
			{
				this.Log().Warn("fb setup not supported");
			}

			return true;
		}

		public virtual void OnRender(GLContext context)
		{
		}

		public bool UseES
		{
			get => _useES;
			set => _useES = value;
		}

		public void SetRequiredVersion(int major, int minor)
		{
			required_gl_version = major * 10 + minor;
		}

		public bool HasAlpha
		{
			get => _hasAlpha;
			set
			{
				if (_hasAlpha != value)
				{
					_hasAlpha = value;

					gtk_gl_area_delete_buffers();
				}
			}
		}

		public bool HasDepthBuffer
		{
			get => _hasDepthBuffer;
			set
			{
				if (_hasDepthBuffer != value)
				{
					_hasDepthBuffer = value;

					_haveBuffers = false;
				}
			}
		}

		public bool HasStencilBuffer
		{
			get => _hasStencilBuffer;
			set
			{
				if (_hasStencilBuffer != value)
				{
					_hasStencilBuffer = value;

					_haveBuffers = false;
				}
			}
		}

		public void QueueRender()
		{
			_needsRender = true;
			QueueDraw();
		}

		public bool AutoRender
		{
			get => _autoRender;
			set
			{
				if (_autoRender != value)
				{
					_autoRender = value;

					if (_autoRender)
					{
						QueueDraw();
					}
				}
			}
		}

		public GLContext? Context => _context;

		public void MakeCurrent()
		{
			if (!IsRealized)
			{
				throw new InvalidOperationException($"Widget is not realized");
			}

			_context?.MakeCurrent();
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
