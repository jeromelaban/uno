#nullable enable

using System;
using System.Runtime.InteropServices;
using Gdk;
using Gtk;
using LibVLCSharp.Shared;

namespace LibVLCSharp.GTK
{
	/// <summary>
	/// GTK VideoView for Windows, Linux and Mac.
	/// Mac is currently unsupported (see https://github.com/mono/gtk-sharp/issues/257)
	/// </summary>
	public class VideoView : DrawingArea, IVideoView
	{
		int _videoHeight;
		int _videoWidth;
		struct Native
		{
			[DllImport("libgdk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr gdk_win32_window_get_handle(IntPtr window);

			/// <summary>
			/// Gets the window's HWND
			/// </summary>
			/// <remarks>Window only</remarks>
			/// <param name="gdkWindow">The pointer to the GdkWindow object</param>
			/// <returns>The window's HWND</returns>
			[DllImport("libgdk-3-0.dll", CallingConvention = CallingConvention.Cdecl)]
			internal static extern IntPtr gdk_win32_drawable_get_handle(IntPtr gdkWindow);

			/// <summary>
			/// Gets the window's XID
			/// </summary>
			/// <remarks>Linux X11 only</remarks>
			/// <param name="gdkWindow">The pointer to the GdkWindow object</param>
			/// <returns>The window's XID</returns>
			[DllImport("libgdk-x11-2.0.so.0", CallingConvention = CallingConvention.Cdecl)]
			internal static extern uint gdk_x11_drawable_get_xid(IntPtr gdkWindow);

			/// <summary>
			/// Gets the nsview's handle
			/// </summary>
			/// <remarks>Mac only</remarks>
			/// <param name="gdkWindow">The pointer to the GdkWindow object</param>
			/// <returns>The nsview's handle</returns>
			[DllImport("libgdk-quartz-2.0.0.dylib")]
			internal static extern IntPtr gdk_quartz_window_get_nsview(IntPtr gdkWindow);
		}

		private MediaPlayer? _mediaPlayer;

		/// <summary>
		/// GTK VideoView constructor
		/// </summary>
		public VideoView()
		{
			Core.Initialize();

			//            Color black = Color.Zero;
			//#pragma warning disable CS0612 // Type or member is obsolete
			//            Color.Parse("black", ref black);
			//            ModifyBg(StateType.Normal, black);
			//#pragma warning restore CS0612 // Type or member is obsolete

			Realized += (s, e) => Attach();
		}

		/// <summary>
		/// The MediaPlayer property for that GTK VideoView
		/// </summary>
		public MediaPlayer? MediaPlayer
		{
			get
			{
				return _mediaPlayer;
			}
			set
			{
				if (ReferenceEquals(_mediaPlayer, value))
				{
					return;
				}

				Detach();
				_mediaPlayer = value;
				Attach();
			}
		}

		void Attach()
		{
			if (!IsRealized || _mediaPlayer == null)
			{
				return;
			}

			if (PlatformHelper.IsWindows)
			{
				Console.WriteLine($"Player attached ({this.Window.Handle})");
#pragma warning disable CS0618 // Type or member is obsolete
				_mediaPlayer.Hwnd = Native.gdk_win32_window_get_handle(this.Window.Handle);
#pragma warning restore CS0618 // Type or member is obsolete
			}
			else if (PlatformHelper.IsLinux)
			{
				_mediaPlayer.XWindow = Native.gdk_x11_drawable_get_xid(this.Window.Handle);
			}
			else if (PlatformHelper.IsMac)
			{
				_mediaPlayer.NsObject = Native.gdk_quartz_window_get_nsview(this.Window.Handle);
			}
			else
			{
				throw new PlatformNotSupportedException();
			}

		}

		void Detach()
		{
			if (!IsRealized || _mediaPlayer == null)
			{
				return;
			}

			if (PlatformHelper.IsWindows)
			{
				_mediaPlayer.Hwnd = IntPtr.Zero;
			}
			else if (PlatformHelper.IsLinux)
			{
				_mediaPlayer.XWindow = 0;
			}
			else if (PlatformHelper.IsMac)
			{
				_mediaPlayer.NsObject = IntPtr.Zero;
			}
			else
			{
				throw new PlatformNotSupportedException();
			}
		}
		protected override void OnGetPreferredHeight(out int minimum_height, out int natural_height)
		{
			minimum_height = 0;
			natural_height = _videoHeight;
		}

		protected override void OnGetPreferredWidth(out int minimum_width, out int natural_width)
		{
			minimum_width = 0;
			natural_width = _videoWidth;
		}
		protected override void OnAdjustSizeRequest(Orientation orientation, out int minimum_size, out int natural_size)
		{
			//minimum_size = 0;
			//natural_size = _videoHeight;
			base.OnAdjustSizeRequest(orientation, out minimum_size, out natural_size);
		}
		protected override SizeRequestMode OnGetRequestMode() => SizeRequestMode.WidthForHeight;
		protected override void OnGetPreferredHeightAndBaselineForWidth(int width, out int minimum_height, out int natural_height, out int minimum_baseline, out int natural_baseline)
		{
			minimum_height = 100;
			natural_height = _videoHeight;
			minimum_baseline = 100;
			natural_baseline = 100;
		}
		protected override void OnGetPreferredHeightForWidth(int width, out int minimum_height, out int natural_height)
		{
			minimum_height = 0;
			natural_height = _videoHeight;
		}
		protected override void OnGetPreferredWidthForHeight(int height, out int minimum_width, out int natural_width)
		{
			minimum_width = 0;
			natural_width = _videoWidth;
		}
		public void SetNaturalSize(int videoHeight, int videoWidth)
		{
			_videoHeight = videoHeight;
			_videoWidth = videoWidth;
		}
	}
}
