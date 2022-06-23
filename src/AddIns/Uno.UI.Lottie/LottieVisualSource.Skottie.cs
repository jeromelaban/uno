#nullable enable

#if __SKIA__ || NET6_0
using System;
using System.Threading;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using System.Threading.Tasks;
using Uno.Disposables;
using SkiaSharp;
using Uno.Foundation.Logging;
using Windows.UI.Xaml;
using Windows.System;
using System.Diagnostics;
using SkiaSharp.SceneGraph;
using Windows.UI.Xaml.Media;

#if HAS_UNO_WINUI
using SkiaSharp.Views.Windows;
#else
using SkiaSharp.Views.UWP;
#endif

namespace Microsoft.Toolkit.Uwp.UI.Lottie
{
	partial class LottieVisualSourceBase
	{
		private UIElement? _renderSurface;
		private SkiaSharp.Skottie.Animation? _animation;
		private SKXamlCanvas? _softwareCanvas;
		private SKSwapChainPanel? _hardwareCanvas;
		private DispatcherQueueTimer? _timer;

		public bool UseHardwareAcceleration { get; set; }
#if __SKIA__
			= false;
#else
			= true;
#endif

		private Uri? _lastSource;
		private (double fromProgress, double toProgress, bool looped)? _playState;

		private Stopwatch _stopwatch = new Stopwatch();
		private TimeSpan? _progress;

		private InvalidationController? _invalidationController;
		private readonly SerialDisposable _animationDataSubscription = new SerialDisposable();

		async Task InnerUpdate(CancellationToken ct)
		{
			var player = _player;

			if (player == null)
			{
				return;
			}

			await SetProperties();

			async Task SetProperties()
			{
				var sourceUri = UriSource;
				if (_lastSource == null || !_lastSource.Equals(sourceUri))
				{
					_lastSource = sourceUri;
					if ((await TryLoadDownloadJson(sourceUri, ct)) is { } jsonStream)
					{
						var cacheKey = sourceUri.OriginalString;
						_animationDataSubscription.Disposable = null;
						_animationDataSubscription.Disposable =
							LoadAndObserveAnimationData(jsonStream, cacheKey, OnJsonChanged);

						void OnJsonChanged(string updatedJson, string updatedCacheKey)
						{
							if (SkiaSharp.Skottie.Animation.TryParse(updatedJson, out var animation))
							{
								animation.Seek(0);

								if (this.Log().IsEnabled(LogLevel.Debug))
								{
									this.Log().Debug($"Version: {animation.Version} Duration: {animation.Duration} Fps:{animation.Fps} InPoint: {animation.InPoint} OutPoint: {animation.OutPoint}");
								}
							}
							else
							{
								throw new InvalidOperationException("Failed to load animation.");
							}

							SetAnimation(animation);

							if (_playState != null)
							{
								var (fromProgress, toProgress, looped) = _playState.Value;
								Play(fromProgress, toProgress, looped);
							}
						}
					}
					else
					{
						throw new NotSupportedException($"Failed to load animation: {sourceUri}");
					}

					// Force layout to recalculate
					player.InvalidateMeasure();
					player.InvalidateArrange();

					if (_playState != null)
					{
						var (fromProgress, toProgress, looped) = _playState.Value;
						Play(fromProgress, toProgress, looped);
					}
					else if (player.AutoPlay)
					{
						Play(0, 1, true);
					}
				}

				if (_animation == null)
				{
					return;
				}

				//switch (player.Stretch)
				//{
				//	case Windows.UI.Xaml.Media.Stretch.None:
				//		_animation.ContentMode = _ViewContentMode.Center;
				//		break;
				//	case Windows.UI.Xaml.Media.Stretch.Uniform:
				//		_animation.ContentMode = _ViewContentMode.ScaleAspectFit;
				//		break;
				//	case Windows.UI.Xaml.Media.Stretch.Fill:
				//		_animation.ContentMode = _ViewContentMode.ScaleToFill;
				//		break;
				//	case Windows.UI.Xaml.Media.Stretch.UniformToFill:
				//		_animation.ContentMode = _ViewContentMode.ScaleAspectFill;
				//		break;
				//}

				var duration = _animation.Duration;
				player.SetValue(AnimatedVisualPlayer.DurationProperty, duration);

				var isLoaded = duration > TimeSpan.Zero;
				player.SetValue(AnimatedVisualPlayer.IsAnimatedVisualLoadedProperty, isLoaded);
			}
		}

		private void SetAnimation(SkiaSharp.Skottie.Animation animation)
		{
			if (!ReferenceEquals(_animation, animation))
			{
#if __IOS__ || __MACOS__
				_renderSurface?.RemoveFromSuperview();
#elif __SKIA__
				_player?.RemoveChild(_renderSurface);
#endif
			}

			_renderSurface = BuildRenderSurface();

#if __IOS__
			_player?.Add(_renderSurface);
#elif __MACOS__
			_player?.AddSubview(_renderSurface);
#elif __SKIA__
			_player?.AddChild(_renderSurface);
#endif

			_animation = animation;
		}

		private UIElement BuildRenderSurface()
		{
			ClearRenderSurface();

			if (UseHardwareAcceleration)
			{
				_hardwareCanvas = new();
				_hardwareCanvas.PaintSurface += OnHardwareCanvas_PaintSurface;
				return _hardwareCanvas;
			}
			else
			{
				_softwareCanvas = new();
				_softwareCanvas.PaintSurface += OnSoftwareCanvas_PaintSurface;
				return _softwareCanvas;
			}
		}

		private void ClearRenderSurface()
		{
			if (UseHardwareAcceleration)
			{
				if (_hardwareCanvas != null)
				{
					_hardwareCanvas.PaintSurface -= OnHardwareCanvas_PaintSurface;
				}
			}
			else
			{
				if(_softwareCanvas != null)
				{
					_softwareCanvas.PaintSurface -= OnSoftwareCanvas_PaintSurface;
				}
			}
		}

		private void OnSoftwareCanvas_PaintSurface(object? sender, SKPaintSurfaceEventArgs e)
		{
			Render(e.Surface);
		}

		private void OnHardwareCanvas_PaintSurface(object? sender, SKPaintGLSurfaceEventArgs e)
		{
			Render(e.Surface);
		}

		private void Render(SKSurface surface)
		{
			var canvas = surface.Canvas;

			var animation = _animation;
			if (animation is null || _player is null)
			{
				return;
			}

			if (_invalidationController is null)
			{
				_invalidationController = new SkiaSharp.SceneGraph.InvalidationController();
				_invalidationController.Begin();
			}

			var frameTime = GetFrameTime();

			var localSize = surface.Canvas.LocalClipBounds.Size;

			var scaledSize = ImageSizeHelper.AdjustSize(_player.Stretch, localSize.ToSize(), animation.Size.ToSize()).ToSKSize();

			var x = (localSize.Width - scaledSize.Width) / 2;
			var y = (localSize.Height - scaledSize.Height) / 2;

			var dst = _player.Stretch switch
			{
				Stretch.None => new SKRect(
					x,
					y,
					scaledSize.Width,
					scaledSize.Height),
				Stretch.Uniform => new SKRect(
					x,
					y,
					scaledSize.Width,
					scaledSize.Height),
				Stretch.Fill => new SKRect(
					x,
					y,
					scaledSize.Width,
					scaledSize.Height),
				Stretch.UniformToFill => new SKRect(
					x,
					y,
					scaledSize.Width,
					scaledSize.Height),
				_ => new SKRect(
					x,
					y,
					animation.Size.Width,
					animation.Size.Height),
			};

			animation.SeekFrameTime(frameTime, _invalidationController);

			canvas.Save();

			canvas.Clear(GetBackgroundColor());
			animation.Render(canvas, dst);

			canvas.Restore();

			_invalidationController.Reset();
		}

		private SKColor GetBackgroundColor()
		{
			if(_player?.Background is SolidColorBrush sb)
			{
				return new SKColor(alpha: sb.ColorWithOpacity.A, red: sb.ColorWithOpacity.R, green: sb.ColorWithOpacity.G, blue: sb.ColorWithOpacity.B);
			}

			return SKColors.Transparent;
		}

		private TimeSpan GetFrameTime()
		{
			if (_animation is null || _timer is null || _playState is null || _player is null)
			{
				return _progress ?? TimeSpan.Zero;
			}

			var frameTime = TimeSpan.FromSeconds((_stopwatch.Elapsed.TotalSeconds + _playState.Value.fromProgress) * _player.PlaybackRate);

			if (frameTime > TimeSpan.FromSeconds(_playState.Value.toProgress))
			{
				if (_playState?.looped ?? false)
				{
					_stopwatch.Restart();
					_invalidationController?.End();
					_invalidationController?.Begin();
				}
				else
				{
					Stop();
				}
			}

			if (!_stopwatch.IsRunning)
			{
				frameTime = _animation.Duration;
			}
			
			return frameTime;
		}

		public void Play(double fromProgress, double toProgress, bool looped)
		{
			if (_animation != null)
			{
				_playState = (_animation.Duration.TotalSeconds * fromProgress, _animation.Duration.TotalSeconds * toProgress, looped);

				if (_stopwatch.IsRunning)
				{
					Stop();
				}

				void Start()
				{
					_timer?.Stop();
					_timer = null;
					_progress = null;
					
					_timer = DispatcherQueue.GetForCurrentThread().CreateTimer();
					_timer.Tick += (s, e) => Invalidate();

					_timer.Interval = TimeSpan.FromSeconds(Math.Max(1 / 120d, 1 / _animation.Fps));
					_timer.Start();
					_stopwatch.Restart();
				}

				Start();
				SetIsPlaying(true);
			}
		}

		private void Invalidate()
		{
			if (UseHardwareAcceleration)
			{
				_hardwareCanvas?.Invalidate();
			}
			else
			{
				_softwareCanvas?.Invalidate();
			}
		}

		public void Stop()
		{
			_playState = null;
			SetIsPlaying(false);
			_timer?.Stop();
			_stopwatch.Stop();
			_invalidationController?.End();
		}

		public void Pause()
		{
			_timer?.Stop();
			_stopwatch.Stop();

			SetIsPlaying(false);
		}

		public void Resume()
		{
			_stopwatch.Start();
			_timer?.Start();
			
			SetIsPlaying(true);
		}

		public void SetProgress(double progress)
		{
			var clampedProgress = Math.Max(0, Math.Min(1, progress));

			if (_animation != null)
			{
				Stop();
				_progress = TimeSpan.FromSeconds(_animation.Duration.TotalSeconds * clampedProgress);
				Invalidate();
			}
		}

		public void Load()
		{
			if (_player?.IsPlaying ?? false)
			{
				Resume();
			}
		}

		public void Unload()
		{
			if (_player?.IsPlaying ?? false)
			{
				Pause();
			}
		}

		private Size CompositionSize
			=> _animation?.Size is { } size
				? new Size(size.Width, size.Height)
				: default;
	}
}
#endif
