using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using Windows.Foundation;
using System.Runtime.CompilerServices;
using System.Text;
using Windows.UI.Xaml.Input;
using Microsoft.Extensions.Logging;
using Uno.Extensions;
using Uno.UI;
using Uno.Disposables;

namespace Windows.UI.Xaml
{
	public partial class FrameworkElement : UIElement, IFrameworkElement
	{
		private readonly SerialDisposable _backgroundSubscription = new SerialDisposable();
		public T FindFirstParent<T>() where T : class
		{
			var view = this.Parent;
			while (view != null)
			{
				var typed = view as T;
				if (typed != null)
				{
					return typed;
				}
				view = view.GetParent() as DependencyObject;
			}
			return null;
		}

		partial void Initialize();

		public FrameworkElement(string htmlTag = "div", bool isSvg = false) : base(htmlTag, isSvg)
		{
			Initialize();

			if (!FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded)
			{
				Loading += NativeOnLoading;
				Loaded += NativeOnLoaded;
				Unloaded += NativeOnUnloaded;
			}

			_log = this.Log();
			_logDebug = _log.IsEnabled(LogLevel.Debug) ? _log : null;
		}

		private protected readonly ILogger _log;
		private protected readonly ILogger _logDebug;

		private static readonly Uri DefaultBaseUri = new Uri("ms-appx://local");
		public global::System.Uri BaseUri
		{
			get;
			internal set;
		} = DefaultBaseUri;

		protected virtual void OnLoaded()
		{

		}

		protected virtual void OnUnloaded()
		{

		}

		#region Transitions Dependency Property

		public TransitionCollection Transitions
		{
			get => _transitionsPropertyBackingField;
			set { this.SetValue(TransitionsProperty, value); }
		}

		public static readonly DependencyProperty TransitionsProperty =
			DependencyProperty.Register(
				name: "Transitions",
				propertyType: typeof(TransitionCollection),
				ownerType: typeof(FrameworkElement),
				typeMetadata: new PropertyMetadata(
					defaultValue: null,
					propertyChangedCallback: OnTransitionsChanged,
					backingFieldUpdateCallback: (s, newValue) => ((FrameworkElement)s)._transitionsPropertyBackingField = (TransitionCollection)newValue));

		private TransitionCollection _transitionsPropertyBackingField = null;

		private static void OnTransitionsChanged(object dependencyObject, DependencyPropertyChangedEventArgs args)
		{

		}
		#endregion

		public IFrameworkElement FindName(string name)
			=> IFrameworkElementHelper.FindName(this, GetChildren(), name);


		public void Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Size AdjustArrange(Size finalSize)
		{
			return finalSize;
		}

		#region Background DependencyProperty

		public Brush Background
		{
			get => _backgroundPropertyBackingField;
			set => SetValue(BackgroundProperty, value);
		}

		public static readonly DependencyProperty BackgroundProperty =
			DependencyProperty.Register(
				name: "Background",
				propertyType: typeof(Brush),
				ownerType: typeof(FrameworkElement),
				typeMetadata: new PropertyMetadata(
					defaultValue: null,
					propertyChangedCallback: (s, e) => ((FrameworkElement)s)?.OnBackgroundChanged(e),
					backingFieldUpdateCallback: (s, newValue) => ((FrameworkElement)s)._backgroundPropertyBackingField = (Brush)newValue
				)
			);

		private Brush _backgroundPropertyBackingField = null;

		protected virtual void OnBackgroundChanged(DependencyPropertyChangedEventArgs e)
		{
			_backgroundSubscription.Disposable = null;
			var brush = e.NewValue as Brush;
			SetBackgroundBrush(brush);

			if (brush is ImageBrush imgBrush)
			{
				RecalculateBrushOnSizeChanged(false);
				_backgroundSubscription.Disposable = imgBrush.Subscribe(img =>
				{
					switch (img.Kind)
					{
						case ImageDataKind.Empty:
						case ImageDataKind.Error:
							ResetStyle("background-color");
							ResetStyle("background-image");
							break;

						case ImageDataKind.Base64:
						case ImageDataKind.Url:
						default:
							ResetStyle("background-color");
							SetStyle("background-image", "url(" + img.Value + ")");
							break;
					}
				});
			}
			else
			{
				_backgroundSubscription.Disposable = Brush.AssignAndObserveBrush(brush, _ => SetBackgroundBrush(brush));
			}
		}

		private protected void SetBackgroundBrush(Brush brush)
		{
			switch (brush)
			{
				case SolidColorBrush solidColorBrush:
					var color = solidColorBrush.ColorWithOpacity;
					SetStyle("background-color", color.ToHexString());
					ResetStyle("background-image");
					RecalculateBrushOnSizeChanged(false);
					break;
				case GradientBrush gradientBrush:
					ResetStyle("background-color");
					SetStyle("background-image", gradientBrush.ToCssString(RenderSize));
					RecalculateBrushOnSizeChanged(true);
					break;
				default:
					ResetStyle("background-color");
					ResetStyle("background-image");
					RecalculateBrushOnSizeChanged(false);
					break;
			}
		}

		private static readonly SizeChangedEventHandler _onSizeChangedForBrushCalculation = (sender, args) =>
		{
			var fe = sender as FrameworkElement;
			fe.SetBackgroundBrush(fe.Background);
		};

		private bool _onSizeChangedForBrushCalculationSet = false;

		private void RecalculateBrushOnSizeChanged(bool shouldRecalculate)
		{
			if (_onSizeChangedForBrushCalculationSet == shouldRecalculate)
			{
				return;
			}

			if (shouldRecalculate)
			{
				SizeChanged += _onSizeChangedForBrushCalculation;
			}
			else
			{
				SizeChanged -= _onSizeChangedForBrushCalculation;
			}

			_onSizeChangedForBrushCalculationSet = shouldRecalculate;
		}

		#endregion

		#region IsEnabled DependencyProperty

		public event DependencyPropertyChangedEventHandler IsEnabledChanged;

		public bool IsEnabled
		{
			get
			{
				Console.WriteLine($"{GetHashCode():X8} Get cached IsEnabled: {_isEnabledPropertyBackingField}");
				return _isEnabledPropertyBackingField;
			}

			set { SetValue(IsEnabledProperty, value); }
		}

		public static readonly DependencyProperty IsEnabledProperty =
			DependencyProperty.Register(
				name: "IsEnabled",
				propertyType: typeof(bool),
				ownerType: typeof(FrameworkElement),
				typeMetadata: new FrameworkPropertyMetadata(
					defaultValue: true,
					options: FrameworkPropertyMetadataOptions.Inherits,
					propertyChangedCallback: (s, e) =>
					{
						Console.WriteLine($"{((FrameworkElement)s).GetHashCode():X8} property changed IsEnabled: {e.NewValue}");

						var elt = (FrameworkElement)s;
						elt?.OnIsEnabledChanged((bool)e.OldValue, (bool)e.NewValue);
						elt?.IsEnabledChanged?.Invoke(s, e);
					},
					coerceValueCallback: (s, v) => (s as FrameworkElement)?.CoerceIsEnabled(v),
					backingFieldUpdateCallback: (s, newValue) =>
					{
						Console.WriteLine($"{((FrameworkElement)s).GetHashCode():X8} update cached IsEnabled: {newValue}");

						((FrameworkElement)s)._isEnabledPropertyBackingField = (bool)newValue;
					})
		);

		private bool _isEnabledPropertyBackingField = true;

		protected virtual void OnIsEnabledChanged(bool oldValue, bool newValue)
		{
			UpdateHitTest();

			// TODO: move focus elsewhere if control.FocusState != FocusState.Unfocused
			if (FeatureConfiguration.UIElement.AssignDOMXamlProperties)
			{
				UpdateDOMProperties();
			}
		}

		#endregion

		public int? RenderPhase
		{
			get => throw new NotImplementedException();
			set => throw new NotImplementedException();
		}

		public void ApplyBindingPhase(int phase) => throw new NotImplementedException();
	}
}
