﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Uno.Extensions;
using Uno.Foundation.Logging;
using Uno.UI.RemoteControl.HotReload;
using Uno.UI.RemoteControl.HotReload.Messages;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
#if __IOS__
using _View = UIKit.UIView;
#else
using _View = Microsoft.UI.Xaml.FrameworkElement;
using System.Runtime.Loader;
using System.Runtime.CompilerServices;
using Java.Lang;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using static System.Diagnostics.DebuggableAttribute;







#endif
#if __IOS__
using UIKit;
#elif __MACOS__
using AppKit;
#elif __ANDROID__
using Uno.UI;
#endif

[assembly: System.Reflection.Metadata.MetadataUpdateHandler(typeof(Uno.UI.RemoteControl.HotReload.ClientHotReloadProcessor))]

namespace Uno.UI.RemoteControl.HotReload
{
	partial class ClientHotReloadProcessor
	{
		private Dictionary<string, Type>? _mappedTypes;

		private bool _supportsLightweightHotReload;

		private Task? _updatingTypes;
		private object _updatingTypesGate = new();

		private void BuildOriginalMappedTypes()
		{
			_supportsLightweightHotReload = (_msbuildProperties?.TryGetValue("TargetFramework", out var targetFramework) ?? false)
				&& (_msbuildProperties?.TryGetValue("BuildingInsideVisualStudio", out var buildingInsideVisualStudio) ?? false)
				&& buildingInsideVisualStudio.Equals("true", StringComparison.OrdinalIgnoreCase)
				&& (
					targetFramework.Contains("-android")
					|| targetFramework.Contains("-ios"));

			_mappedTypes = _supportsLightweightHotReload
				? BuildMappedTypes()
				: new();
		}

		private async Task LightweightReload(FileReload fileReload)
		{
			if (!_supportsLightweightHotReload)
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"Skipping file reload");
				}

				return;
			}

			if (!fileReload.IsValid())
			{
				if (fileReload.FilePath is not null && this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"FileReload is missing a file path");
				}

				if (fileReload.Content is null && this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"FileReload is missing content");
				}

				return;
			}

			lock (_updatingTypesGate)
			{
				if (_updatingTypes == null || _updatingTypes.Status is TaskStatus.RanToCompletion or TaskStatus.Faulted)
				{
					_updatingTypes = ObserveUpdateTypeMapping();
				}
				else
				{
					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().Debug($"LightweightReload: Waiting for existing type observer");
					}
				}
			}

			await _updatingTypes;
		}

		private async Task ObserveUpdateTypeMapping()
		{
			var originalMappedTypes = _mappedTypes ?? new();
			var sw = Stopwatch.StartNew();

			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"ObserveUpdateTypeMapping: Start observing (Original mapped types {originalMappedTypes.Count})");
			}

			while (sw.Elapsed < TimeSpan.FromSeconds(15))
			{
				// Arbitrary delay to wait for VS to push updates to the app
				// so we can discover which types have changed
				await Task.Delay(250);

				var mappedSw = Stopwatch.StartNew();
				// Lookup for types marked with MetadataUpdateOriginalTypeAttribute
				var mappedTypes = BuildMappedTypes();

				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().Debug($"ObserveUpdateTypeMapping: fetched mapped types {mappedTypes.Count} in {mappedSw.Elapsed}");
				}

				if (!mappedTypes.Values.All(b => originalMappedTypes.ContainsValue(b)))
				{
					_mappedTypes = mappedTypes;

					var newTypes = mappedTypes
						.Values
						.Except(originalMappedTypes.Values)
						.ToArray();

					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						var types = string.Join(", ", _mappedTypes.Values);

						this.Log().Debug($"Found {newTypes.Length} updated types ({types})");
					}

					var actions = _agent.GetMetadataUpdateHandlerActions();

					actions.ClearCache.ForEach(a => a(newTypes));
					actions.UpdateApplication.ForEach(a => a(newTypes));

					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().Debug($"ObserveUpdateTypeMapping: Invoked metadata updaters");
					}

					return;
				}
			}

			if (this.Log().IsEnabled(LogLevel.Debug))
			{
				this.Log().Debug($"ObserveUpdateTypeMapping: Stopped observing after timeout");
			}
		}

		private Dictionary<string, Type> BuildMappedTypes()
		{
			var mappedTypes =
					from asm in AssemblyLoadContext.Default.Assemblies
					let debuggableAttribute = asm.GetCustomAttribute<DebuggableAttribute>()
					where debuggableAttribute is not null
						&& (debuggableAttribute.DebuggingFlags & DebuggingModes.DisableOptimizations) != 0
					from type in asm.GetTypes()
					let originalType = type.GetCustomAttribute<MetadataUpdateOriginalTypeAttribute>()
					where originalType is not null
					group type by originalType.OriginalType into g
					select new
					{
						Key = g.Key.FullName,
						Type = g.Key,
						LastMapped = g.OrderBy(t => t.FullName).Last()
					};

			return mappedTypes.ToDictionary(p => p.Key, p => p.LastMapped);
		}
	}
}
