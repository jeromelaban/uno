#nullable enable

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
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
#if __IOS__
using _View = UIKit.UIView;
#else
using _View = Windows.UI.Xaml.FrameworkElement;
using System.Runtime.Loader;
using System.Runtime.CompilerServices;
using Java.Lang;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;






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
		private Dictionary<string, Type> _mappedTypes;

		private bool _supportsLightweightHotReload;

		private Task? _updatingTypes;
		private object _updatingTypesGate = new();

		[MemberNotNull(nameof(_mappedTypes))]
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
			}

			await _updatingTypes;
		}

		private async Task ObserveUpdateTypeMapping()
		{
			var originalMappedTypes = _mappedTypes;
			var sw = Stopwatch.StartNew();

			while (sw.Elapsed < TimeSpan.FromSeconds(15))
			{
				// Arbitrary delay to wait for VS to push updates to the app
				// so we can discover which types have changed
				await Task.Delay(250);

				// Lookup for types marked with MetadataUpdateOriginalTypeAttribute
				var mappedTypes = BuildMappedTypes();

				if (originalMappedTypes.Count != mappedTypes.Count)
				{
					_mappedTypes = mappedTypes;

					var newOriginalTypes = mappedTypes
						.Keys
						.Except(originalMappedTypes.Keys)
						.ToArray();

					if (this.Log().IsEnabled(LogLevel.Debug))
					{
						this.Log().Debug($"Found {newOriginalTypes.Length} updated types");
					}

					var newTypes = newOriginalTypes
						.Select(t => _mappedTypes[t])
						.ToArray();

					var actions = _agent.GetMetadataUpdateHandlerActions();

					actions.ClearCache.ForEach(a => a(newTypes));
					actions.UpdateApplication.ForEach(a => a(newTypes));

					return;
				}
			}
		}

		private Dictionary<string, Type> BuildMappedTypes()
		{
			var mappedTypes =
					from asm in AssemblyLoadContext.Default.Assemblies
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
