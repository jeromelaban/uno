#nullable enable

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Uno.Equality;
using Uno.Extensions;
using Uno.Roslyn;

#if NETFRAMEWORK
using Uno.SourceGeneration;
#endif

namespace Uno.UI.SourceGenerators.XamlGenerator
{
	internal class GenerationRunInfoManager
	{
		private List<GenerationRunInfo> _runs = new List<GenerationRunInfo>();

		private record HashInfo(string AssemblyName, int Hash);
		/// <summary>
		/// A list of known hashes for the current process to avoid removing previously
		/// generated hashes and break Roslyn's metadata generator with inconsistent missing
		/// methods.
		/// </summary>
		private static ConcurrentDictionary<HashInfo, object?> _knownAdditionalFilesHashes = new();

		internal GenerationRunInfoManager()
		{
			foreach (var hash in _knownAdditionalFilesHashes.ToArray())
			{
				_runs.Add(new(this, hash.Key.Hash, hash.Key.AssemblyName));
			}
		}

		public IEnumerable<GenerationRunInfo> GetAllRunsForAssembly(string assemblyName)
			=> _runs
			.Where(r => r.AssemblyName == assemblyName)
			.AsEnumerable();

		internal GenerationRunInfo CreateRun(GeneratorExecutionContext context)
		{
			var assemblyName = context.Compilation.Assembly.Name;

			ReadProjectConfiguration(
				context,
				out var useXamlReaderHotReload,
				out var useHotReload);

			var hash = context
				.AdditionalFiles
				.Aggregate(0, (hash, f) => ByteSequenceComparer.GetHashCode(f.GetText()?.GetChecksum() ?? ImmutableArray<byte>.Empty) ^ hash);

			// Only create a new run when the previous run additional files are different
			// This ensures that each run produces the same output for a given input.
			if (
				!useXamlReaderHotReload
				&& useHotReload
				&& _runs.FirstOrDefault(r =>
				{
					return r.AdditionalFilesHash == hash && r.AssemblyName == assemblyName;
				}) is { } run)
			{
				return run;
			}
			else
			{
				var runInfo = new GenerationRunInfo(this, hash, assemblyName);

				_runs.Add(runInfo);

				_knownAdditionalFilesHashes.TryAdd(new(assemblyName, hash), null);

				return runInfo;
			}
		}

		private static void ReadProjectConfiguration(GeneratorExecutionContext context, out bool useXamlReaderHotReload, out bool useHotReload)
		{
			bool.TryParse(context.GetMSBuildPropertyValue("UnoUseXamlReaderHotReload"), out useXamlReaderHotReload);

			var configuration = context.GetMSBuildPropertyValue("Configuration")
				?? throw new InvalidOperationException("The configuration property must be provided");

			if (bool.TryParse(context.GetMSBuildPropertyValue("UnoForceHotReloadCodeGen"), out var forceHotReloadCodeGen))
			{
				useHotReload = forceHotReloadCodeGen;
			}
			else
			{
				useHotReload = string.Equals(configuration, "Debug", StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
