#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Uno.UI.SourceGenerators.XamlGenerator;

public record ResourceDetails(string Assembly, string FileName, string Key);

internal class ResourceDetailsCollection
{
	private string _localAssemblyName;

	private Dictionary<string, Dictionary<string, ResourceDetails>> _resourcesByFileName = new();
	private Dictionary<string, Dictionary<string, List<ResourceDetails>>> _partialResourcesByFileName = new();

	public ResourceDetailsCollection(string localAssemblyName)
	{
		_localAssemblyName = localAssemblyName;
	}

	public bool HasLocalResources { get; internal set; }

	public void AddRange(ResourceDetails[] resources)
	{
		foreach (var resource in resources)
		{
			if (resource.Assembly == _localAssemblyName)
			{
				HasLocalResources = true;
			}

			// Resources by file name
			if(!_resourcesByFileName.TryGetValue(resource.FileName, out var fileResources))
			{
				_resourcesByFileName[resource.FileName] = fileResources = new();
			}

			fileResources[resource.Key] = resource;

			// Resource by partial name
			if(!_partialResourcesByFileName.TryGetValue(resource.FileName, out var partialResources))
			{
				_partialResourcesByFileName[resource.FileName] = partialResources = new();
			}

			var memberIndex = resource.Key.LastIndexOf('.');

			if(memberIndex != -1)
			{
				var partialName = resource.Key.Substring(0, memberIndex);

				if(!partialResources.TryGetValue(partialName, out var partials))
				{
					partialResources[partialName] = partials = new();
				}

				partials.Add(resource);
			}
		}
	}

	internal IEnumerable<ResourceDetails> FindByPartialUId(string partialUid)
	{
		var (resourceFileName, uidName) = ParseXUid(partialUid);

		if (_partialResourcesByFileName.TryGetValue(resourceFileName, out var fileResources))
		{
			if (fileResources.TryGetValue(uidName, out var resourceDetail))
			{
				return resourceDetail;
			}
		}

		return Enumerable.Empty<ResourceDetails>();
	}

	internal ResourceDetails? FindByUId(string uid)
	{
		var (resourceFileName, uidName) = ParseXUid(uid);

		if(_resourcesByFileName.TryGetValue(resourceFileName, out var fileResources))
		{
			if(fileResources.TryGetValue(uidName, out var resourceDetail))
			{
				return resourceDetail;
			}
		}

		return null;
	}

	(string resourceFileName, string uidName) ParseXUid(string uid)
	{
		if (uid.StartsWith("/", StringComparison.Ordinal))
		{
			// Skip the current assembly name for self lookup
			var startIndex = uid.StartsWith("/" + _localAssemblyName, StringComparison.Ordinal)
				? _localAssemblyName.Length + 2
				: 1;

			var separator = uid.IndexOf('/', startIndex);

			return (
				uid.Substring(startIndex, separator - startIndex),
				uid.Substring(separator + 1)
			);
		}
		else
		{
			return ("Resources", uid);
		}
	}
}
