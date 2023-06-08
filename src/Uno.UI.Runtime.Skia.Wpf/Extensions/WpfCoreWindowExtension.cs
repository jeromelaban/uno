﻿#nullable enable

using Windows.UI.Core;
using System.Windows.Input;
using Uno.UI.Skia.Platform.Extensions;
using Uno.Foundation.Logging;
using WpfCanvas = System.Windows.Controls.Canvas;
using Windows.UI.Xaml;
using Uno.UI.Hosting;
using Uno.UI.Runtime.Skia.Wpf.Hosting;

namespace Uno.UI.Skia.Platform
{
	internal partial class WpfCoreWindowExtension : ICoreWindowExtension
	{
		private readonly WpfHost? _host;
		private readonly CoreWindow _owner;

		public CoreCursor PointerCursor
		{
			get => Mouse.OverrideCursor.ToCoreCursor();
			set => Mouse.OverrideCursor = value.ToCursor();
		}

		public WpfCoreWindowExtension(object owner)
		{
			_owner = (CoreWindow)owner;
			_host = WpfHost.Current;

			// TODO:MZ: Multi-window, attach to main window
			//_host = WpfHost.Current;
			//if (_host is null)
			//{
			//	return;
			//}

			//// Hook for native events
			//_host.Loaded += HookNative;

			//void HookNative(object sender, System.Windows.RoutedEventArgs e)
			//{
			//	_host.Loaded -= HookNative;

			//	var win = System.Windows.Window.GetWindow(_host);

			//	win.AddHandler(System.Windows.UIElement.KeyUpEvent, (System.Windows.Input.KeyEventHandler)HostOnKeyUp, true);
			//	win.AddHandler(System.Windows.UIElement.KeyDownEvent, (System.Windows.Input.KeyEventHandler)HostOnKeyDown, true);
			//}
		}

		internal static WpfCanvas? GetOverlayLayer(XamlRoot xamlRoot) =>
			XamlRootMap<IWpfXamlRootHost>.GetHostForRoot(xamlRoot)?.NativeOverlayLayer;

		public bool IsNativeElement(object content)
			=> content is System.Windows.UIElement;

		public void AttachNativeElement(object owner, object content)
		{
			if (owner is XamlRoot xamlRoot
				&& GetOverlayLayer(xamlRoot) is { } layer
				&& content is System.Windows.FrameworkElement contentAsFE
				&& contentAsFE.Parent != layer)
			{
				layer.Children.Add(contentAsFE);
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Unable to attach native element {content} in {owner}.");
				}
			}
		}

		public void DetachNativeElement(object owner, object content)
		{
			if (owner is XamlRoot xamlRoot
				&& GetOverlayLayer(xamlRoot) is { } layer
				&& content is System.Windows.FrameworkElement contentAsFE
				&& contentAsFE.Parent != layer)
			{
				layer.Children.Add(contentAsFE);
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Unable to detach native element {content} in {owner}.");
				}
			}
		}

		public void ArrangeNativeElement(object owner, object content, Windows.Foundation.Rect arrangeRect)
		{
			if (content is System.Windows.UIElement contentAsUIElement)
			{
				WpfCanvas.SetLeft(contentAsUIElement, arrangeRect.X);
				WpfCanvas.SetTop(contentAsUIElement, arrangeRect.Y);

				contentAsUIElement.Arrange(
					new(0, 0, arrangeRect.Width, arrangeRect.Height)
				);
			}
			else
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Unable to arrange native element {content} in {owner}.");
				}
			}
		}

		public Windows.Foundation.Size MeasureNativeElement(object owner, object content, Windows.Foundation.Size size)
		{
			return size;
		}
	}
}
