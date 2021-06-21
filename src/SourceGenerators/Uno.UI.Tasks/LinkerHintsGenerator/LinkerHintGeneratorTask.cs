#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Transactions;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using Mono.Cecil;
using Uno.UI.SourceGenerators.BindableTypeProviders;

namespace Uno.UI.Tasks.LinkerHintsGenerator
{
	/// <summary>
	/// Task used to generate a linker feature list, based on all features being disabled.
	/// </summary>
	public class LinkerHintGeneratorTask_v0 : Microsoft.Build.Utilities.Task
	{
		private const MessageImportance DefaultLogMessageLevel
#if DEBUG
			= MessageImportance.High;
#else
			= MessageImportance.Low;
#endif

		private List<string> _referencedAssemblies = new List<string>();

		[Required]
		public string AssemblyPath { get; set; } = "";

		[Required]
		public string CurrentProjectPath { get; set; } = "";

		[Required]
		public string ILLinkerPath { get; set; } = "";

		[Required]
		public string OutputPath { get; set; } = "";

		[Required]
		public Microsoft.Build.Framework.ITaskItem[]? ReferencePath { get; set; }

		[Output]
		public Microsoft.Build.Framework.ITaskItem[]? OutputFeatures { get; set; }

		public override bool Execute()
		{
			// Debugger.Launch();

			BuildReferences();
			OutputPath = AlignPath(OutputPath);

			var pass1Path = Path.Combine(OutputPath, "pass1");

			var features = BuildLinkerFeaturesList();

			Log.LogMessage(DefaultLogMessageLevel, $"Running linker pass 1");

			RunLinker(pass1Path, features);

			var pass1Features = BuildResultingFeaturesList(pass1Path);
			var pass1LinkerFeatures = string.Join(" ", pass1Features.Select(h => $"--feature {h.Key} {h.Value}"));

			Log.LogMessage(DefaultLogMessageLevel, $"Running linker pass 2");
			RunLinker(OutputPath, pass1LinkerFeatures);

			var finalFeatures = BuildResultingFeaturesList(OutputPath);

			OutputFeatures = finalFeatures
				.Select(f => new TaskItem(f.Key, new Dictionary<string, string> { ["Value"] = f.Value }))
				.ToArray();

			return true;
		}

		private void RunLinker(string outputPath, string features)
		{
			var linkerPath = Path.Combine(ILLinkerPath, "illink.dll");

			var linkerSearchPaths = string.Join(" ", _referencedAssemblies.Select(Path.GetDirectoryName).Distinct().Select(p => $"-d \"{p}\" "));

			var parameters = new List<string>()
			{
				$"--feature UnoBindableMetadata false",
				$"--verbose",
				$"--deterministic",
				$"--used-attrs-only true",
				$"--skip-unresolved true",
				$"-b true",
				$"-a {AssemblyPath}",
				$"-out {outputPath}",
				linkerSearchPaths,
				features,
			};

			var paramString = string.Join("\n", parameters);
			var file = Path.GetTempFileName();
			File.WriteAllText(file, paramString);

			Directory.CreateDirectory(OutputPath);

			var res = StartProcess("dotnet", $"{linkerPath} @{file}", CurrentProjectPath);

			if (!string.IsNullOrEmpty(res.error))
			{
				Log.LogError(res.error);
			}
		}

		private Dictionary<string, string> BuildResultingFeaturesList(string resultPath)
		{
			var sourceList = new List<string>();
			sourceList.AddRange(Directory.GetFiles(resultPath, "*.dll"));

			var assemblies = new List<AssemblyDefinition>(
				from asmPath in sourceList.Distinct()
				let asm = ReadAssembly(asmPath)
				where asm != null
				select asm
			);

			var features = new Dictionary<string, string>();

			var availableLinkerHints = FindAvailableLinkerHints(assemblies);

			foreach(var hint in availableLinkerHints)
			{
				features[hint] = "false";
			}

			foreach (var asm in assemblies)
			{
				foreach(var type in asm.MainModule.Types)
				{
					if (IsDependencyObject(type))
					{
						features[LinkerHintsHelpers.GetPropertyAvailableName(type.FullName)] = "true";
					}
				}
			}

			return features;
		}

		private bool IsDependencyObject(TypeDefinition type)
		{
			if(type.Interfaces.Any(c => c.InterfaceType.FullName == "Windows.UI.Xaml.DependencyObject"))
			{
				return true;
			}

			try
			{
				if (type.BaseType != null && IsDependencyObject(type.BaseType.Resolve()))
				{
					return true;
				}
			}
			catch(Exception e)
			{

			}

			return false;
		}

		private string BuildLinkerFeaturesList()
		{
			var assemblySearchList = BuildResourceSearchList();

			var hints = FindAvailableLinkerHints(assemblySearchList);

			return string.Join(" ", hints.Select(h => $"--feature {h} false"));
		}

		private static List<string> FindAvailableLinkerHints(List<AssemblyDefinition> assemblySearchList)
		{
			var hints = new List<string>();

			foreach (var asm in assemblySearchList)
			{
				if (asm.MainModule.Types.FirstOrDefault(t => t.Name == "__LinkerHints") is { } linkerHints)
				{
					foreach (var prop in linkerHints.Properties)
					{
						hints.Add(prop.Name);
					}
				}
			}

			return hints.Distinct().ToList();
		}

		private List<AssemblyDefinition> BuildResourceSearchList()
		{
			var sourceList = new List<string>();

			sourceList.AddRange(_referencedAssemblies);

			// Add the main assembly last so it can have a final say
			sourceList.Add(AssemblyPath);

			return new List<AssemblyDefinition>(
				from asmPath in sourceList.Distinct()
				let asm = ReadAssembly(asmPath)
				where asm != null
				select asm
			);
		}

		private AssemblyDefinition? ReadAssembly(string asmPath)
		{
			try
			{
				return AssemblyDefinition.ReadAssembly(asmPath);
			}
			catch (Exception ex)
			{
				Log.LogMessage(MessageImportance.Low, $"Failed to read assembly {ex}");
				return null;
			}
		}

		private void BuildReferences()
		{
			if (ReferencePath != null)
			{
				foreach (var referencePath in ReferencePath)
				{
					var isReferenceAssembly = referencePath.GetMetadata("PathInPackage")?.StartsWith("ref/", StringComparison.OrdinalIgnoreCase) ?? false;
					var hasConcreteAssembly = isReferenceAssembly && ReferencePath.Any(innerReference => HasConcreteAssemblyForReferenceAssembly(innerReference, referencePath));

					var name = Path.GetFileName(referencePath.ItemSpec);
					_referencedAssemblies.Add(referencePath.ItemSpec);
				}
			}
		}

		private static bool HasConcreteAssemblyForReferenceAssembly(ITaskItem other, ITaskItem referenceAssembly)
			=> Path.GetFileName(other.ItemSpec) == Path.GetFileName(referenceAssembly.ItemSpec) && (other.GetMetadata("PathInPackage")?.StartsWith("lib/", StringComparison.OrdinalIgnoreCase) ?? false);


		private string AlignPath(string outputPath)
			=> outputPath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar).Replace(new string(Path.DirectorySeparatorChar, 2), Path.DirectorySeparatorChar.ToString());

		private (int exitCode, string output, string error) StartProcess(string executable, string parameters, string workingDirectory)
		{
			Log.LogMessage(
				DefaultLogMessageLevel,
				$"[{workingDirectory}] {executable} {parameters}");

			var p = new Process
			{
				StartInfo =
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					FileName = executable,
					Arguments = parameters
				}
			};

			if (workingDirectory != null)
			{
				p.StartInfo.WorkingDirectory = workingDirectory;
			}

			var output = new StringBuilder();
			var error = new StringBuilder();
			var elapsed = Stopwatch.StartNew();

			p.OutputDataReceived += (s, e) => { if (e.Data != null) { Log.LogMessage(DefaultLogMessageLevel, $"[{elapsed.Elapsed}] {e.Data}"); output.Append(e.Data); } };
			p.ErrorDataReceived += (s, e) => { if (e.Data != null) { Log.LogError($"[{elapsed.Elapsed}] {e.Data}"); error.Append(e.Data); } };

			if (p.Start())
			{
				p.BeginOutputReadLine();
				p.BeginErrorReadLine();
				p.WaitForExit();
				var exitCore = p.ExitCode;
				p.CancelErrorRead();
				p.CancelOutputRead();
				p.Close();

				return (exitCore, output.ToString(), error.ToString());
			}
			else
			{
				throw new Exception($"Failed to start [{executable}]");
			}

		}
	}
}
