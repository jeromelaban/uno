using System;
using Uno.Extensions;
using Uno.UI;
using Uno.UI.DataBinding;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Windows.UI.Xaml.Controls
{
	/// <summary>
	/// Declares a Content presenter
	/// </summary>
	/// <remarks>
	/// The content presenter is used for compatibility with WPF concepts,
	/// but the ContentSource property is not available, because there are ControlTemplates for now.
	/// </remarks>
	public partial class ContentPresenter : FrameworkElement
	{
		private BorderLayerRenderer _borderRenderer = new BorderLayerRenderer();
		private Rect? _lastArrangeRect;
		private Rect _lastGlobalRect;
		private bool _nativeHostRegistered;

		public ContentPresenter()
		{
			InitializeContentPresenter();

			Loaded += (s, e) => { UpdateBorder(); RegisterNativeHostSupport(); };
			Unloaded += (s, e) => { _borderRenderer.Clear(); UnregisterNativeHostSupport(); };
			LayoutUpdated += (s, e) => UpdateBorder();
		}

		private void SetUpdateTemplate()
		{
			UpdateContentTemplateRoot();
		}

		partial void RegisterContentTemplateRoot()
		{
			AddChild(ContentTemplateRoot);
		}

		partial void UnregisterContentTemplateRoot()
		{
			RemoveChild(ContentTemplateRoot);
		}

		void RegisterNativeHostSupport()
		{
			if (IsNativeHost && XamlRoot is not null)
			{
				XamlRoot.InvalidateRender += UpdateNativeElementPosition;
				_nativeHostRegistered = true;
			}
		}

		void UnregisterNativeHostSupport()
		{
			if (_nativeHostRegistered)
			{
				_nativeHostRegistered = false;
				XamlRoot.InvalidateRender -= UpdateNativeElementPosition;
			}
		}

		private void UpdateCornerRadius(CornerRadius radius) => UpdateBorder();

		private void UpdateBorder()
		{
			if (IsLoaded)
			{
				_borderRenderer.UpdateLayer(
					this,
					Background,
					BackgroundSizing,
					BorderThickness,
					BorderBrush,
					CornerRadius,
					null
				);
			}
		}

		partial void OnPaddingChangedPartial(Thickness oldValue, Thickness newValue)
		{
			UpdateBorder();
		}

		bool ICustomClippingElement.AllowClippingToLayoutSlot => true;

		bool ICustomClippingElement.ForceClippingToLayoutSlot => CornerRadius != CornerRadius.None;

		private void ArrangeNativeElement(Rect arrangeRect)
		{
			if (IsNativeHost)
			{
				_lastArrangeRect = arrangeRect;

				UpdateNativeElementPosition();
			}
		}

		private Size MeasureNativeElement(Size size)
		{
			if (IsNativeHost)
			{
				return CoreWindow.Main.MeasureNativeElement(XamlRoot, Content, size);
			}
			else
			{
				return size;
			}
		}

		private void UpdateNativeElementPosition()
		{
			if (_lastArrangeRect is { } lastArrangeRect)
			{
				var globalPosition = TransformToVisual(null).TransformPoint(lastArrangeRect.Location);
				var globalRect = new Rect(globalPosition, lastArrangeRect.Size);

				if (_lastGlobalRect != globalRect)
				{
					_lastGlobalRect = globalRect;

					CoreWindow.Main.ArrangeNativeElement(XamlRoot, Content, globalRect);
				}
			}
		}
	}
}
