using System;
using System.Timers;
using Uno.UI.Converters;
using Windows.Media.Playback;
using Windows.UI.Core;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Uno.UI.Xaml.Controls.MediaPlayer.Internal;
using System.Drawing;
using Windows.Foundation;
using Windows.UI.Xaml.Media.Animation;
using Uno.Disposables;
using Windows.UI.Xaml.Controls.Primitives;

#if HAS_UNO_WINUI
using Microsoft.UI.Input;
using PointerDeviceType = Microsoft.UI.Input.PointerDeviceType;
#else
using Windows.UI.Input;
using PointerDeviceType = Windows.Devices.Input.PointerDeviceType;
#endif

#if __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#elif __ANDROID__
using Uno.UI;
#endif

namespace Windows.UI.Xaml.Controls
{
	[TemplatePart(Name = "RootGrid", Type = typeof(Grid))]
	[TemplatePart(Name = "PlayPauseButton", Type = typeof(Button))]
	[TemplatePart(Name = "PlayPauseButtonOnLeft", Type = typeof(Button))]
	[TemplatePart(Name = "VolumeMuteButton", Type = typeof(Button))]
	[TemplatePart(Name = "AudioMuteButton", Type = typeof(Button))]
	[TemplatePart(Name = "VolumeSlider", Type = typeof(Slider))]
	[TemplatePart(Name = "FullWindowButton", Type = typeof(Button))]
	[TemplatePart(Name = "CastButton", Type = typeof(Button))]
	[TemplatePart(Name = "ZoomButton", Type = typeof(Button))]
	[TemplatePart(Name = "PlaybackRateButton", Type = typeof(Button))]
	[TemplatePart(Name = "PlaybackRateButton", Type = typeof(Button))]
	[TemplatePart(Name = "SkipForwardButton", Type = typeof(Button))]
	[TemplatePart(Name = "NextTrackButton", Type = typeof(Button))]
	[TemplatePart(Name = "FastForwardButton", Type = typeof(Button))]
	[TemplatePart(Name = "RewindButton", Type = typeof(Button))]
	[TemplatePart(Name = "PreviousTrackButton", Type = typeof(Button))]
	[TemplatePart(Name = "SkipBackwardButton", Type = typeof(Button))]
	[TemplatePart(Name = "StopButton", Type = typeof(Button))]
	[TemplatePart(Name = "AudioTracksSelectionButton", Type = typeof(Button))]
	[TemplatePart(Name = "CCSelectionButton", Type = typeof(Button))]
	[TemplatePart(Name = "TimeElapsedElement", Type = typeof(TextBlock))]
	[TemplatePart(Name = "TimeRemainingElement", Type = typeof(TextBlock))]
	[TemplatePart(Name = "ProgressSlider", Type = typeof(Slider))]
	[TemplatePart(Name = "BufferingProgressBar", Type = typeof(ProgressBar))]
	[TemplatePart(Name = "DownloadProgressIndicator", Type = typeof(ProgressBar))]
	[TemplatePart(Name = "ControlPanelGrid", Type = typeof(Grid))]
	[TemplatePart(Name = ControlPanelBorderName, Type = typeof(Border))]
	public partial class MediaTransportControls : Control
	{
		private const string RootGridName = "RootGrid";
		private const string PlayPauseButtonName = "PlayPauseButton";
		private const string PlayPauseButtonOnLeftName = "PlayPauseButtonOnLeft";
		private const string VolumeMuteButtonName = "VolumeMuteButton";
		private const string AudioMuteButtonName = "AudioMuteButton";
		private const string VolumeSliderName = "VolumeSlider";
		private const string FullWindowButtonName = "FullWindowButton";
		private const string CastButtonName = "CastButton";
		private const string ZoomButtonName = "ZoomButton";
		private const string PlaybackRateButtonName = "PlaybackRateButton";
		private const string SkipForwardButtonName = "SkipForwardButton";
		private const string RepeatVideoButtonName = "RepeatVideoButton";
		private const string NextTrackButtonName = "NextTrackButton";
		private const string FastForwardButtonName = "FastForwardButton";
		private const string RewindButtonName = "RewindButton";
		private const string PreviousTrackButtonName = "PreviousTrackButton";
		private const string SkipBackwardButtonName = "SkipBackwardButton";
		private const string StopButtonName = "StopButton";
		private const string AudioTracksSelectionButtonName = "AudioTracksSelectionButton";
		private const string CCSelectionButtonName = "CCSelectionButton";
		private const string TimeElapsedElementName = "TimeElapsedElement";
		private const string TimeRemainingElementName = "TimeRemainingElement";
		private const string ProgressSliderName = "ProgressSlider";
		private const string BufferingProgressBarName = "BufferingProgressBar";
		private const string TimelineContainerName = "MediaTransportControls_Timeline_Border";
		private const string HorizontalThumbName = "HorizontalThumb";
		private const string DownloadProgressIndicatorName = "DownloadProgressIndicator";
		private const string CompactOverlayButtonName = "CompactOverlayButton";
		private const string ControlPanelGridName = "ControlPanelGrid";
		private const string ControlPanelBorderName = "ControlPanel_ControlPanelVisibilityStates_Border";

		private Grid _rootGrid;
		private Button _playPauseButton;
		private Button _playPauseButtonOnLeft;
		private Button _volumeMuteButton;
		private Button _audioMuteButton;
		private Slider _volumeSlider;
		private Button _fullWindowButton;
		private Button _castButton;
		private Button _zoomButton;
		private Button _playbackRateButton;
		private Button _skipForwardButton;
		private Button _repeatVideoButton;
		private Button _nextTrackButton;
		private Button _fastForwardButton;
		private Button _rewindButton;
		private Button _compactOverlayButton;
		private Button _previousTrackButton;
		private Button _skipBackwardButton;
		private Button _stopButton;
		private Button _audioTracksSelectionButton;
		private Button _ccSelectionButton;
		private TextBlock _timeElapsedElement;
		private TextBlock _timeRemainingElement;
		private Slider _progressSlider;
		private ProgressBar _bufferingProgressBar;
		private Border _timelineContainer;
		private ProgressBar _downloadProgressIndicator;
		private Grid _controlPanelGrid;
		private Border _controlPanelBorder;

		private DispatcherTimer _controlsVisibilityTimer;
		private bool _wasPlaying;
		private bool _isShowingControls = true;
		private MediaPlayerElement _mpe;
		private CompositeDisposable _loadedSubscriptions;

		public MediaTransportControls() : base()
		{
			_controlsVisibilityTimer = new()
			{
				Interval = TimeSpan.FromSeconds(3)
			};

			_controlsVisibilityTimer.Tick += ControlsVisibilityTimerElapsed;

			DefaultStyleKey = typeof(MediaTransportControls);
			Loaded += MediaTransportControls_Loaded;
			Unloaded += MediaTransportControls_Unloaded;
		}

		private void MediaTransportControls_Unloaded(object sender, RoutedEventArgs e)
		{
			_rootGrid = this.GetTemplateChild(RootGridName) as Grid;
			if (_rootGrid != null)
			{
				_rootGrid.Tapped -= OnRootGridTapped;
			}

			_controlPanelGrid = this.GetTemplateChild(ControlPanelGridName) as Grid;
			if (_controlPanelGrid != null)
			{
				_controlPanelGrid.Tapped -= OnPaneGridTapped;
			}
		}

		private void MediaTransportControls_Loaded(object sender, RoutedEventArgs e)
		{
			_rootGrid = this.GetTemplateChild(RootGridName) as Grid;
			if (_rootGrid != null)
			{
				_rootGrid.Tapped += OnRootGridTapped;
			}

			_controlPanelGrid = this.GetTemplateChild(ControlPanelGridName) as Grid;
			if (_controlPanelGrid != null)
			{
				_controlPanelGrid.Tapped += OnPaneGridTapped;
			}
		}

		internal void SetMediaPlayerElement(MediaPlayerElement mediaPlayerElement)
		{
			_mpe = mediaPlayerElement;
		}

		private void ControlsVisibilityTimerElapsed(object sender, object args)
		{
			_controlsVisibilityTimer.Stop();

			if (ShowAndHideAutomatically)
			{
				Hide();
			}
		}

		private void ResetControlsVisibilityTimer()
		{
			if (ShowAndHideAutomatically)
			{
				_controlsVisibilityTimer.Stop();
				_controlsVisibilityTimer.Start();
			}
		}

		private void CancelControlsVisibilityTimer()
		{
			Show();
			_controlsVisibilityTimer.Stop();
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			UnbindMediaPlayer();
			_loadedSubscriptions?.Dispose();

			var trueToVisible = new FromNullableBoolToVisibilityConverter();

			_playPauseButton = this.GetTemplateChild(PlayPauseButtonName) as Button;

			_playPauseButtonOnLeft = this.GetTemplateChild(PlayPauseButtonOnLeftName) as Button;

			_volumeMuteButton = this.GetTemplateChild(VolumeMuteButtonName) as Button;
			_volumeMuteButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsVolumeButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_volumeMuteButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsVolumeEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_audioMuteButton = this.GetTemplateChild(AudioMuteButtonName) as Button;

			_volumeSlider = this.GetTemplateChild(VolumeSliderName) as Slider;
			if (_volumeSlider != null)
			{
				_volumeSlider.Maximum = 100;
				_volumeSlider.Value = 100;
			}

			_fullWindowButton = this.GetTemplateChild(FullWindowButtonName) as Button;
			if (_fullWindowButton is not null)
			{
				_fullWindowButton.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsFullWindowButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
				_fullWindowButton.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsFullWindowEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });
			}

			_castButton = this.GetTemplateChild(CastButtonName) as Button;

			_zoomButton = this.GetTemplateChild(ZoomButtonName) as Button;
			_zoomButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsZoomButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_zoomButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsZoomEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_playbackRateButton = this.GetTemplateChild(PlaybackRateButtonName) as Button;
			_playbackRateButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsPlaybackRateButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_playbackRateButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsPlaybackRateEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_controlPanelGrid = this.GetTemplateChild(ControlPanelGridName) as Grid;

			_compactOverlayButton = this.GetTemplateChild(CompactOverlayButtonName) as Button;
			_compactOverlayButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsCompactOverlayButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_compactOverlayButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsCompactOverlayEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_controlPanelBorder = this.GetTemplateChild(ControlPanelBorderName) as Border;

			_repeatVideoButton = this.GetTemplateChild(RepeatVideoButtonName) as Button;
			_repeatVideoButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsRepeatButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_repeatVideoButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsRepeatEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_skipForwardButton = this.GetTemplateChild(SkipForwardButtonName) as Button;
			_skipForwardButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsSkipForwardButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_skipForwardButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsSkipForwardEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_nextTrackButton = this.GetTemplateChild(NextTrackButtonName) as Button;
			_nextTrackButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsNextTrackButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });

			_previousTrackButton = this.GetTemplateChild(PreviousTrackButtonName) as Button;
			_previousTrackButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsPreviousTrackButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });

			_fastForwardButton = this.GetTemplateChild(FastForwardButtonName) as Button;
			_fastForwardButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsFastForwardButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_fastForwardButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsFastForwardEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_rewindButton = this.GetTemplateChild(RewindButtonName) as Button;
			_rewindButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsFastRewindButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_rewindButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsFastRewindEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_skipBackwardButton = this.GetTemplateChild(SkipBackwardButtonName) as Button;
			_skipBackwardButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsSkipBackwardButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_skipBackwardButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsSkipBackwardEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_stopButton = this.GetTemplateChild(StopButtonName) as Button;
			_stopButton?.SetBinding(Button.VisibilityProperty, new Binding { Path = "IsStopButtonVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_stopButton?.SetBinding(Button.IsEnabledProperty, new Binding { Path = "IsStopEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });

			_audioTracksSelectionButton = this.GetTemplateChild(AudioTracksSelectionButtonName) as Button;

			_ccSelectionButton = this.GetTemplateChild(CCSelectionButtonName) as Button;

			_timeElapsedElement = this.GetTemplateChild(TimeElapsedElementName) as TextBlock;

			_timeRemainingElement = this.GetTemplateChild(TimeRemainingElementName) as TextBlock;

			_progressSlider = this.GetTemplateChild(ProgressSliderName) as Slider;
			PropertyChangedCallback callback = OnSliderTemplateChanged;
			_progressSlider?.RegisterDisposablePropertyChangedCallback(Slider.TemplateProperty, callback);

			_bufferingProgressBar = this.GetTemplateChild(BufferingProgressBarName) as ProgressBar;

			_timelineContainer = this.GetTemplateChild(TimelineContainerName) as Border;
			_timelineContainer?.SetBinding(Border.VisibilityProperty, new Binding { Path = "IsSeekBarVisible", Source = this, Mode = BindingMode.OneWay, FallbackValue = Visibility.Collapsed, Converter = trueToVisible });
			_progressSlider?.SetBinding(Control.IsEnabledProperty, new Binding { Path = "IsSeekEnabled", Source = this, Mode = BindingMode.OneWay, FallbackValue = true });
			_downloadProgressIndicator = _progressSlider?.GetTemplateChild(DownloadProgressIndicatorName) as ProgressBar;

			UpdateMediaTransportControlMode();

			_rootGrid = this.GetTemplateChild(RootGridName) as Grid;

			if (_mediaPlayer is not null)
			{
				BindMediaPlayer();
			}

			if (IsLoaded)
			{
				BindToControlEvents();
			}
		}

		internal override void OnLayoutUpdated()
		{
			base.OnLayoutUpdated();

			OnControlsBoundsChanged();
		}

		private protected override void OnLoaded()
		{
			base.OnLoaded();

			BindToControlEvents();
		}

		private void BindToControlEvents()
		{
			_loadedSubscriptions = new();

			if (_rootGrid is not null)
			{
				_rootGrid.Tapped += OnRootGridTapped;
				_rootGrid.PointerMoved += OnRootGridPointerMoved;

				_loadedSubscriptions.Add(() =>
				{
					_rootGrid.Tapped -= OnRootGridTapped;
					_rootGrid.PointerMoved -= OnRootGridPointerMoved;
				});
			}

			if (_fullWindowButton is not null)
			{
				_fullWindowButton.Tapped += FullWindowButtonTapped;

				_loadedSubscriptions.Add(() => _fullWindowButton.Tapped -= FullWindowButtonTapped);
			}

			if (_zoomButton is not null)
			{
				_zoomButton.Tapped += ZoomButtonTapped;

				_loadedSubscriptions.Add(() => _zoomButton.Tapped -= ZoomButtonTapped);
			}

			if (_playbackRateButton is not null)
			{
				_playbackRateButton.Tapped += PlaybackRateButtonTapped;

				_loadedSubscriptions.Add(() => _playbackRateButton.Tapped -= PlaybackRateButtonTapped);
			}

			if (_compactOverlayButton is not null)
			{
				_compactOverlayButton.Click += UpdateCompactOverlayMode;

				_loadedSubscriptions.Add(() => _compactOverlayButton.Click -= UpdateCompactOverlayMode);
			}

			if (_controlPanelGrid is not null)
			{
				_controlPanelGrid.SizeChanged += ControlPanelGridSizeChanged;

				_loadedSubscriptions.Add(() => _controlPanelGrid.SizeChanged -= ControlPanelGridSizeChanged);
			}

			if (_controlPanelBorder is not null)
			{
				_controlPanelBorder.SizeChanged += ControlPanelBorderSizeChanged;

				_loadedSubscriptions.Add(() => _controlPanelBorder.SizeChanged -= ControlPanelBorderSizeChanged);
			}

			if (_repeatVideoButton is not null)
			{
				_repeatVideoButton.Tapped += IsRepeatEnabledButtonTapped;

				_loadedSubscriptions.Add(() => _repeatVideoButton.Tapped -= IsRepeatEnabledButtonTapped);
			}

			if (_nextTrackButton is not null)
			{
				_nextTrackButton.Tapped -= NextTrackButtonTapped;

				_loadedSubscriptions.Add(() => _nextTrackButton.Tapped -= NextTrackButtonTapped);
			}

			if (_previousTrackButton is not null)
			{
				_previousTrackButton.Tapped -= PreviousTrackButtonTapped;

				_loadedSubscriptions.Add(() => _previousTrackButton.Tapped -= PreviousTrackButtonTapped);
			}

			// Register on visual state changes to update the layout in extensions
			foreach (var groups in VisualStateManager.GetVisualStateGroups(this.GetTemplateRoot()))
			{
				foreach (var state in groups.States)
				{
					if (state.Name is "ControlPanelFadeOut")
					{
						foreach (var child in state.Storyboard.Children)
						{
							// Update the layout on opacity completed
							if (child.PropertyInfo?.LeafPropertyName == "Opacity")
							{
								child.Completed += Storyboard_Completed;

								_loadedSubscriptions.Add(() => child.Completed += Storyboard_Completed);
							}
						}
					}
				}
			}
		}

		private protected override void OnUnloaded()
		{
			base.OnUnloaded();

			_loadedSubscriptions?.Dispose();
			_loadedSubscriptions = null;
		}

		private void Storyboard_Completed(object sender, object e)
			=> OnControlsBoundsChanged();

		private void ControlPanelGridSizeChanged(object sender, SizeChangedEventArgs args)
		{
			OnControlsBoundsChanged();
		}

		private static void ControlPanelBorderSizeChanged(object sender, SizeChangedEventArgs args)
		{
			if (sender is Border border)
			{
				border.Clip = new RectangleGeometry { Rect = new Rect(0, 0, args.NewSize.Width, args.NewSize.Height) };
			}
		}

		private void FullWindowButtonTapped(object sender, RoutedEventArgs e)
		{
			_mpe.IsFullWindow = !_mpe.IsFullWindow;
			UpdateFullscreenButtonStyle();
		}
		private void PlaybackRateButtonTapped(object sender, RoutedEventArgs e)
		{
			_mpe.MediaPlayer.PlaybackRate += 0.25;
		}
		private void IsRepeatEnabledButtonTapped(object sender, RoutedEventArgs e)
		{
			_mpe.MediaPlayer.IsLoopingEnabled = !_mpe.MediaPlayer.IsLoopingEnabled;
		}
		private void PreviousTrackButtonTapped(object sender, RoutedEventArgs e)
		{
			_mediaPlayer.PlaybackSession.Position = TimeSpan.Zero;
			_mpe.MediaPlayer.PlaybackSession.Position = TimeSpan.Zero;
		}
		private void NextTrackButtonTapped(object sender, RoutedEventArgs e)
		{
			_mediaPlayer.PlaybackSession.Position = _mediaPlayer.PlaybackSession.NaturalDuration;
			_mpe.MediaPlayer.PlaybackSession.Position = _mediaPlayer.PlaybackSession.NaturalDuration;
		}

		private void UpdateFullscreenButtonStyle()
		{
			if (_mpe.IsFullWindow)
			{
				VisualStateManager.GoToState(this, "FullWindowState", false);
			}
			else
			{
				VisualStateManager.GoToState(this, "NonFullWindowState", false);
			}
		}

		private void ZoomButtonTapped(object sender, RoutedEventArgs e)
		{
			if (_mpe.Stretch == Stretch.Uniform)
			{
				_mpe.Stretch = Stretch.UniformToFill;
			}
			else
			{
				_mpe.Stretch = Stretch.Uniform;
			}
		}

		public void Show()
		{
			_isShowingControls = true;

			_ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				VisualStateManager.GoToState(this, "ControlPanelFadeIn", false);
			});

			// Adjust layout bounds immediately
			OnControlsBoundsChanged();

			if (ShowAndHideAutomatically)
			{
				ResetControlsVisibilityTimer();
			}
		}

		public void Hide()
		{
			_isShowingControls = false;

			_ = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
			{
				if (_mediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Buffering || _mediaPlayer.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
				{
					VisualStateManager.GoToState(this, "ControlPanelFadeOut", false);
				}
			});
		}

		private void OnControlsBoundsChanged()
		{
			var root = (XamlRoot?.Content as UIElement);
			if (root is null)
			{
				return;
			}

			var bounds = new Rect(
				0,
				0,
				_controlPanelGrid.ActualWidth,
				_isShowingControls ? _controlPanelGrid.ActualHeight : 0);

			var transportBounds = TransformToVisual(root).TransformBounds(bounds);
			_mediaPlayer?.SetTransportControlBounds(transportBounds);
		}

		private void OnPaneGridTapped(object sender, TappedRoutedEventArgs e)
		{
			if (ShowAndHideAutomatically)
			{
				ResetControlsVisibilityTimer();
			}
			e.Handled = true;
		}
		private void OnRootGridTapped(object sender, TappedRoutedEventArgs e)
		{
			if (e.PointerDeviceType == PointerDeviceType.Touch)
			{
				if (_isShowingControls)
				{
					_controlsVisibilityTimer.Stop();
					Hide();
				}
				else
				{
					Show();
				}
			}
		}

		private void OnRootGridPointerMoved(object sender, PointerRoutedEventArgs e)
		{
			Show();
		}

		private void UpdateCompactOverlayMode(object sender, RoutedEventArgs e)
		{
			_mpe.ToogleCompactOverlay(!_mpe.IsCompactOverlay);
		}

		private void UpdateMediaTransportControlMode(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, IsCompact ? "CompactMode" : "NormalMode", true);
			OnControlsBoundsChanged();
		}
		private void UpdateMediaTransportControlMode()
		{
			VisualStateManager.GoToState(this, IsCompact ? "CompactMode" : "NormalMode", true);
			OnControlsBoundsChanged();
		}

		private static void OnIsCompactChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if (dependencyObject is MediaTransportControls mtc)
			{
				mtc.UpdateMediaTransportControlMode();
			}
		}

		private static void OnShowAndHideAutomaticallyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			if ((bool)args.NewValue)
			{
				((MediaTransportControls)dependencyObject).ResetControlsVisibilityTimer();
			}
			else
			{
				((MediaTransportControls)dependencyObject).CancelControlsVisibilityTimer();
			}
		}

		private static void OnIsSeekBarVisibleChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			((MediaTransportControls)dependencyObject)._timelineContainer.Visibility = (bool)args.NewValue ? Visibility.Visible : Visibility.Collapsed;
		}

		private static void OnIsSeekEnabledChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
		{
			VisualStateManager.GoToState(((MediaTransportControls)dependencyObject)._progressSlider, (bool)args.NewValue ? "Normal" : "Disabled", false);
		}
	}
}
