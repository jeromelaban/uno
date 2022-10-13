using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Uno.UI.Tasks.Helpers;
using Windows.ApplicationModel.Resources.Core;

namespace Uno.UI.Tasks.Assets
{
	/// <summary>
	/// Retargets UWP assets to Android and iOS.
	/// </summary>
	/// <remarks>
	/// Currently supports .png, .jpg, .jpeg and .gif.
	/// </remarks>
	public class ExpandPackageAssets_v0 : Task
	{
		[Required]
		public ITaskItem[] MarkerFiles { get; set; }

		[Output]
		public ITaskItem[] Assets { get; set; }

		public override bool Execute()
		{
			Log.LogMessage($"Expanding package assets");

			List<ITaskItem> assets = new();

			foreach(var markerFile in MarkerFiles)
			{
				var markerFileFullPath = markerFile.GetMetadata("FullPath");
				var markerFileDIrectory = Path.GetDirectoryName(markerFileFullPath);
				var basePath = Path.Combine(markerFileDIrectory, Path.GetFileNameWithoutExtension(markerFileFullPath));

				if (Directory.Exists(basePath))
				{
					foreach (var asset in Directory.EnumerateFiles(basePath, "*.*", SearchOption.AllDirectories))
					{
						var newItem = new TaskItem(
							asset,
							new Dictionary<string, string>
							{
								["TargetPath"] = asset.Replace(markerFileDIrectory, "")
							});

						assets.Add(newItem);
					}
				}
			}

			Assets = assets.ToArray();

			return true;
		}
	}
}
