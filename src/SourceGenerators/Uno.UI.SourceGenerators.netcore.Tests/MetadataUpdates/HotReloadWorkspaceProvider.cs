using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using Uno.UI.RemoteControl.Host.HotReload.MetadataUpdates;

namespace Uno.UI.SourceGenerators.MetadataUpdates;

internal class HotReloadWorkspaceProvider
{

	static HotReloadWorkspaceProvider()
	{
		RegisterAssemblyLoader();
	}

	public record Document(string Name, string Content);

	public static async Task CreateProject(
		TaskCompletionSource<(AdhocWorkspace, WatchHotReloadService)> taskCompletionSource,
		IReporter reporter,
		Document[] csFiles,
		Document[] xamlFiles,
		CancellationToken cancellationToken)
	{
		var capsRaw = "Baseline AddMethodToExistingType AddStaticFieldToExistingType AddInstanceFieldToExistingType NewTypeDefinition ChangeCustomAttributes UpdateParameters";
		var caps = capsRaw.Split(" ");

		var workspace = new AdhocWorkspace();

		workspace.WorkspaceFailed += (_sender, diag) =>
		{
			if (diag.Diagnostic.Kind == WorkspaceDiagnosticKind.Warning)
			{
				reporter.Verbose($"MSBuildWorkspace warning: {diag.Diagnostic}");
			}
			else
			{
				if (!diag.Diagnostic.ToString().StartsWith("[Failure] Found invalid data while decoding", StringComparison.Ordinal))
				{
					taskCompletionSource.TrySetException(new InvalidOperationException($"Failed to create MSBuildWorkspace: {diag.Diagnostic}"));
				}
			}
		};

		var currentSolution = workspace.CurrentSolution;
		
		var projectId = ProjectId.CreateNewId();
		var docId = DocumentId.CreateNewId(projectId);

		var references = Directory.GetFiles(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System*.dll")
			.Where(f => !f.Contains(".Native", StringComparison.OrdinalIgnoreCase))
			.Select(f => MetadataReference.CreateFromFile(f))
			.ToArray();

		var baseWorkFolder = Path.Combine(Path.GetDirectoryName(typeof(HotReloadWorkspaceProvider).Assembly.Location)!, "work");
		Directory.CreateDirectory(baseWorkFolder);
		
		Environment.SetEnvironmentVariable("Microsoft_CodeAnalysis_EditAndContinue_LogDir", baseWorkFolder);

		var projectInfo = ProjectInfo.Create(
					projectId,
					VersionStamp.Default,
					name: "project1",
					assemblyName: "project1",
					language: LanguageNames.CSharp,
					filePath: Path.Combine(baseWorkFolder, "project1.csproj"),
					outputFilePath: baseWorkFolder,
					metadataReferences: references);

		projectInfo = projectInfo
			.WithCompilationOutputInfo(
				projectInfo.CompilationOutputInfo.WithAssemblyPath(Path.Combine(baseWorkFolder, "project1.exe")));

		currentSolution = workspace.AddProject(projectInfo).Solution;

		foreach (var document in csFiles)
		{
			var documentId = DocumentId.CreateNewId(currentSolution.Projects.First().Id);
			currentSolution = currentSolution.AddDocument(
				documentId,
				document.Name,
				CSharpSyntaxTree.ParseText(document.Content, encoding: Encoding.UTF8).GetText(),
				filePath: Path.Combine(baseWorkFolder, document.Name)
			);

			File.WriteAllText(Path.Combine(baseWorkFolder, document.Name), document.Content, Encoding.UTF8);
		}

		foreach (var document in xamlFiles)
		{
			var documentId = DocumentId.CreateNewId(currentSolution.Projects.First().Id);
			currentSolution = currentSolution.AddAdditionalDocument(documentId, document.Name, document.Content);
		}
		
		var generatorReference = new MyGeneratorReference(ImmutableArray.Create<ISourceGenerator>(new XamlGenerator.XamlCodeGenerator()));

		//currentSolution = currentSolution.Projects.First().WithAnalyzerReferences(new[] {
		//	generatorReference
		//}).Solution;

		workspace.TryApplyChanges(currentSolution);

		// Read the documents to memory
		await Task.WhenAll(
			currentSolution.Projects.SelectMany(p => p.Documents.Concat(p.AdditionalDocuments)).Select(d => d.GetTextAsync(cancellationToken)));

		// Warm up the compilation. This would help make the deltas for first edit appear much more quickly
		foreach (var p in currentSolution.Projects)
		{
			var c = await p.GetCompilationAsync(cancellationToken);

			if(c is null)
			{
				throw new InvalidOperationException($"Failed to get the compilation for {p}");
			}

			if (c.GetDiagnostics().Any(d => d.DefaultSeverity == DiagnosticSeverity.Error))
			{
				var errors = c.GetDiagnostics().Where(d => d.DefaultSeverity == DiagnosticSeverity.Error);

				throw new InvalidOperationException($"Compilation errors: {string.Join(",", errors)}");
			}

			var e = c.Emit(projectInfo.CompilationOutputInfo.AssemblyPath!, pdbPath: Path.ChangeExtension(projectInfo.CompilationOutputInfo.AssemblyPath, ".pdb"));
		}

		var hotReloadService = new WatchHotReloadService(workspace.Services, caps);
		await hotReloadService.StartSessionAsync(currentSolution, cancellationToken);

		taskCompletionSource.TrySetResult((workspace, hotReloadService));
	}

	private static void RegisterAssemblyLoader()
	{
		// Force assembly loader to consider siblings, when running in a separate appdomain.
		ResolveEventHandler localResolve = (s, e) =>
		{
			if (e.Name == "Mono.Runtime")
			{
				// Roslyn 2.0 and later checks for the presence of the Mono runtime
				// through this check.
				return null;
			}

			var assembly = new AssemblyName(e.Name);
			var basePath = Path.GetDirectoryName(new Uri(typeof(HotReloadWorkspaceProvider).Assembly.Location).LocalPath);

			Console.WriteLine($"Searching for [{assembly}] from [{basePath}]");

			// Ignore resource assemblies for now, we'll have to adjust this
			// when adding globalization.
			if (assembly.Name!.EndsWith(".resources", StringComparison.Ordinal))
			{
				return null;
			}

			// Lookup for the highest version matching assembly in the current app domain.
			// There may be an existing one that already matches, even though the
			// fusion loader did not find an exact match.
			var loadedAsm = (
								from asm in AppDomain.CurrentDomain.GetAssemblies()
								where asm.GetName().Name == assembly.Name
								orderby asm.GetName().Version descending
								select asm
							).ToArray();

			if (loadedAsm.Length > 1)
			{
				var duplicates = loadedAsm
					.Skip(1)
					.Where(a => a.GetName().Version == loadedAsm[0].GetName().Version)
					.ToArray();

				if (duplicates.Length != 0)
				{
					Console.WriteLine($"Selecting first occurrence of assembly [{e.Name}] which can be found at [{string.Join("; ", duplicates.Select(d => d.Location))}]");
				}

				return loadedAsm[0];
			}
			else if (loadedAsm.Length == 1)
			{
				return loadedAsm[0];
			}

			Assembly? LoadAssembly(string filePath)
			{
				if (File.Exists(filePath))
				{
					try
					{
						var output = Assembly.LoadFrom(filePath);

						Console.WriteLine($"Loaded [{output.GetName()}] from [{output.Location}]");

						return output;
					}
					catch (Exception ex)
					{
						Console.WriteLine($"Failed to load [{assembly}] from [{filePath}]", ex);
						return null;
					}
				}
				else
				{
					return null;
				}
			}

			var paths = new[] {
					Path.Combine(basePath!, assembly.Name + ".dll"),
				};

			return paths
				.Select(LoadAssembly)
				.Where(p => p != null)
				.FirstOrDefault();
		};

		AppDomain.CurrentDomain.AssemblyResolve += localResolve;
		AppDomain.CurrentDomain.TypeResolve += localResolve;
	}
}

sealed class MyGeneratorReference : AnalyzerReference
{
	private readonly ImmutableArray<ISourceGenerator> _generators;

	internal MyGeneratorReference(ImmutableArray<ISourceGenerator> generators)
	{
		_generators = generators;
	}

	public override string FullPath
	{
		get { throw new NotImplementedException(); }
	}

	public override object Id
	{
		get { throw new NotImplementedException(); }
	}

	public override ImmutableArray<DiagnosticAnalyzer> GetAnalyzers(string language)
	{
		return ImmutableArray<DiagnosticAnalyzer>.Empty;
	}

	public override ImmutableArray<DiagnosticAnalyzer> GetAnalyzersForAllLanguages()
	{
		return ImmutableArray<DiagnosticAnalyzer>.Empty;
	}

	public override ImmutableArray<ISourceGenerator> GetGenerators(string language)
	{
		return _generators;
	}
}
