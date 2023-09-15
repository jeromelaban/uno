using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AVFoundation;
using CoreGraphics;
using Foundation;

using Photos;
using UIKit;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Storage;

namespace Windows.Media.Capture
{
	public partial class CameraCaptureUI
	{
		private async Task<StorageFile> CaptureFile(CancellationToken ct, CameraCaptureUIMode mode)
		{
			UIImagePickerController picker = null;
			var cameraDelegate = new CameraDelegate();

			if (UIImagePickerController.IsSourceTypeAvailable(UIImagePickerControllerSourceType.Camera))
			{
				picker = new UIImagePickerController();
				picker.Delegate = cameraDelegate;
				picker.AllowsEditing = PhotoSettings.AllowCropping;

				picker.SourceType = UIImagePickerControllerSourceType.Camera;

				switch (mode)
				{
					case CameraCaptureUIMode.Photo:
					case CameraCaptureUIMode.PhotoOrVideo:
						picker.CameraCaptureMode = UIImagePickerControllerCameraCaptureMode.Photo;
						break;

					case CameraCaptureUIMode.Video:
#pragma warning disable CA1416 // UTType.Image, UTType.Movie is supported on ios version 14 and above
						picker.MediaTypes = new string[] { MobileCoreServices.UTType.Movie };
#pragma warning restore CA1416
						picker.CameraCaptureMode = UIImagePickerControllerCameraCaptureMode.Video;

						// TODO
						//if (VideoSettings.Format != CameraCaptureUIVideoFormat.Mp4)
						//{
						//	throw new NotSupportedException("The capture format mp4 is the only one supported");
						//}

						await ValidateCameraAccess();
						await ValidateMicrophoneAccess();
						break;
				}
			}
			else
			{
				// Probably running in the simulator
				if (this.Log().IsEnabled(LogLevel.Warning))
				{
					this.Log().Warn($"'{UIImagePickerControllerSourceType.Camera}' not available - picking from albums");
				}

				picker = new LockedOrientationUIImagePickerController(DisplayInformation.AutoRotationPreferences.ToUIInterfaceOrientationMask())
				{
					// Use the camera roll instead of crashing
					SourceType = UIImagePickerControllerSourceType.PhotoLibrary
				};

				await ValidatePhotoLibraryAccess();
			}

			picker.Delegate = cameraDelegate;
			UIKit.UIApplication.SharedApplication.KeyWindow?.RootViewController.PresentModalViewController(picker, true);

			using (ct.Register(() => picker.DismissViewController(true, () => { }), useSynchronizationContext: true))
			{
				var result = await cameraDelegate.Task;

				if (result != null)
				{
					var image = result.ValueForKey(new NSString("UIImagePickerControllerOriginalImage")) as UIImage;

					if (image is not null)
					{
						var correctedImage = FixOrientation(image);

						(Stream data, string extension) GetImageStream()
						{
							switch (PhotoSettings.Format)
							{
								case CameraCaptureUIPhotoFormat.Jpeg:
									return (image.AsJPEG().AsStream(), ".jpg");

								case CameraCaptureUIPhotoFormat.Png:
									return (image.AsPNG().AsStream(), ".png");

								default:
									throw new NotSupportedException($"{PhotoSettings.Format} is not supported");
							}
						};

						var (data, extension) = GetImageStream();
						return await CreateTempImage(data, extension);
					}
					else
					{
						var assetUrl = result[UIImagePickerController.MediaURL] as NSUrl;
						PHAsset phAsset = null;

						Console.WriteLine($"Asset url {assetUrl}");

						if (assetUrl is not null)
						{
							if (OperatingSystem.IsIOSVersionAtLeast(11, 0))
							{
								if (!assetUrl.Scheme.Equals("assets-library", StringComparison.OrdinalIgnoreCase))
								{
									var doc = new UIDocument(assetUrl);
									var fullPath = doc.FileUrl?.Path;

									return await ConvertToMp4(fullPath);
								}

								phAsset = result.ValueForKey(UIImagePickerController.PHAsset) as PHAsset;
							}

							if (phAsset == null)
							{
								assetUrl = result[UIImagePickerController.ReferenceUrl] as NSUrl;

								if (assetUrl != null)
								{
									phAsset = PHAsset.FetchAssets(new NSUrl[] { assetUrl }, null)?.LastObject as PHAsset;

									if (phAsset is not null)
									{
										string originalFilename = PHAssetResource.GetAssetResources(phAsset).FirstOrDefault()?.OriginalFilename;
										return await ConvertToMp4(originalFilename);
									}
								}
							}
						}
					}
				}

				return null;
			}
		}

		private async Task<StorageFile> ConvertToMp4(string originalFilename)
		{
			var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			var outputFilePath = Path.Combine(ApplicationData.Current.TemporaryFolder.Path, Guid.NewGuid() + ".mp4");

			var asset = AVAsset.FromUrl(NSUrl.FromFilename(originalFilename));

			AVAssetExportSession export = new AVAssetExportSession(asset, AVAssetExportSession.PresetPassthrough);

			export.OutputUrl = NSUrl.FromFilename(outputFilePath);
			export.OutputFileType = AVFileTypesExtensions.GetConstant(AVFileTypes.Mpeg4);
			export.ShouldOptimizeForNetworkUse = true;

			await export.ExportTaskAsync();

			return await StorageFile.GetFileFromPathAsync(outputFilePath);
		}


		// As of iOS 10, usage description keys are required for many more permissions
		private static bool IsUsageKeyDefined(string usageKey)
		{
			return UIDevice.CurrentDevice.CheckSystemVersion(10, 0)
				? NSBundle.MainBundle.ObjectForInfoDictionary(usageKey) != null
				: true;
		}

		private async Task ValidateMicrophoneAccess()
		{
			if (!IsUsageKeyDefined("NSMicrophoneUsageDescription"))
			{
				throw new InvalidOperationException("Info.plist must define NSMicrophoneUsageDescription");
			}

			var isAllowed = (await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVAuthorizationMediaType.Audio));
			if (!isAllowed)
			{
				throw new UnauthorizedAccessException();
			}
		}

		private async Task ValidateCameraAccess()
		{
			if (!IsUsageKeyDefined("NSCameraUsageDescription"))
			{
				throw new InvalidOperationException("Info.plist must define NSCameraUsageDescription");
			}

			var isAllowed = (await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVAuthorizationMediaType.Video));
			if (!isAllowed)
			{
				throw new UnauthorizedAccessException();
			}
		}

		private async Task ValidatePhotoLibraryAccess()
		{
			if (!IsUsageKeyDefined("NSPhotoLibraryUsageDescription"))
			{
				throw new InvalidOperationException("Info.plist must define NSPhotoLibraryUsageDescription");
			}

			var isAllowed = (await PHPhotoLibrary.RequestAuthorizationAsync()) == PHAuthorizationStatus.Authorized;
			if (!isAllowed)
			{
				throw new UnauthorizedAccessException();
			}
		}

		private class LockedOrientationUIImagePickerController : UIImagePickerController
		{
			private readonly UIInterfaceOrientationMask _supportedOrientations;

			public LockedOrientationUIImagePickerController(UIInterfaceOrientationMask supportedOrientations)
			{
				_supportedOrientations = supportedOrientations;
			}

			public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
			{
				return _supportedOrientations;
			}
		}

		/// <summary>
		/// Fixes orientation issues caused by taking an image straight from the camera
		/// </summary>
		/// <param name="image">UI Image</param>
		/// <returns>UI image</returns>
		private static UIImage FixOrientation(UIImage image)
		{
			if (image.Orientation == UIImageOrientation.Up)
			{
				return image;
			}

			// http://stackoverflow.com/questions/5427656/ios-uiimagepickercontroller-result-image-orientation-after-upload
			UIGraphics.BeginImageContextWithOptions(image.Size, false, image.CurrentScale);

			image.Draw(new CGRect(0, 0, image.Size.Width, image.Size.Height));
			var normalizedImage = UIGraphics.GetImageFromCurrentImageContext();

			UIGraphics.EndImageContext();

			return normalizedImage;
		}
	}

	class CameraDelegate : UIImagePickerControllerDelegate
	{
		private readonly TaskCompletionSource<NSDictionary> _cts;

		public CameraDelegate()
		{
			_cts = new TaskCompletionSource<NSDictionary>();
			Task = _cts.Task;
		}

		public Task<NSDictionary> Task { get; }

		public override void FinishedPickingMedia(UIImagePickerController picker, NSDictionary info)
		{
			_cts.TrySetResult(info);
			picker.DismissModalViewController(true);
		}

		public override void Canceled(UIImagePickerController picker)
		{
			base.Canceled(picker);

			_cts.TrySetResult(null);
		}
	}
}
