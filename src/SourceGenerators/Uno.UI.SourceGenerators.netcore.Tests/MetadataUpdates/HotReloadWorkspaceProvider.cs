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
using Uno.UI.SourceGenerators.Tests.Verifiers;

namespace Uno.UI.SourceGenerators.MetadataUpdates;

internal class HotReloadWorkspace
{
	public record UpdateResult(ImmutableArray<Diagnostic> Diagnostics, ImmutableArray<WatchHotReloadService.Update> MetadataUpdates);

	const string CapsRaw = "Baseline AddMethodToExistingType AddStaticFieldToExistingType AddInstanceFieldToExistingType NewTypeDefinition ChangeCustomAttributes UpdateParameters";

	private readonly string _baseWorkFolder;
	private Dictionary<string, Dictionary<string, string>> _sourceFiles = new();
	private Dictionary<string, Dictionary<string, string>> _additionalFiles = new();
	private Solution? _currentSolution;
	private WatchHotReloadService? _hotReloadService;

	public HotReloadWorkspace()
	{
		_baseWorkFolder = Path.Combine(Path.GetDirectoryName(typeof(HotReloadWorkspace).Assembly.Location)!, "work");
		Directory.CreateDirectory(_baseWorkFolder);

		Environment.SetEnvironmentVariable("Microsoft_CodeAnalysis_EditAndContinue_LogDir", _baseWorkFolder);
	}

	public void SetSourceFile(string project, string fileName, string content)
	{
		if (_sourceFiles.TryGetValue(project, out var files))
		{
			files[fileName] = content;
		}
		else
		{
			_sourceFiles[project] = new() {
				[fileName] = content
			};
		}
		var basePath = Path.Combine(_baseWorkFolder, project);
		var filePath = Path.Combine(basePath, fileName);
		Directory.CreateDirectory(basePath);
		File.WriteAllText(filePath, content, Encoding.UTF8);

		if(_currentSolution is not null)
		{
			var documents = _currentSolution
				.Projects
				.SelectMany(p => p.Documents)
				.First(d => d.FilePath == filePath);

			_currentSolution = _currentSolution.WithDocumentText(
				documents.Id,
				CSharpSyntaxTree.ParseText(content, encoding: Encoding.UTF8).GetText());
		}
	}

	public void SetAdditionalFile(string project, string fileName, string content)
	{
		if (_additionalFiles.TryGetValue(project, out var files))
		{
			files[fileName] = content;
		}
		else
		{
			_additionalFiles[project] = new()
			{
				[fileName] = content
			};
		}
		
		var basePath = Path.Combine(_baseWorkFolder, project);
		Directory.CreateDirectory(basePath);
		var filePath = Path.Combine(basePath, fileName);
		File.WriteAllText(filePath, content, Encoding.UTF8);

		if (_currentSolution is not null)
		{
			var documents = _currentSolution
				.Projects
				.SelectMany(p => p.AdditionalDocuments)
				.First(d => d.FilePath == filePath);

			_currentSolution = _currentSolution.WithAdditionalDocumentText(
				documents.Id,
				CSharpSyntaxTree.ParseText(content, encoding: Encoding.UTF8).GetText());
		}
	}

	public async Task Initialize(CancellationToken ct)
	{
		TaskCompletionSource<bool> taskCompletionSource = new();

		var workspace = new AdhocWorkspace();

		workspace.WorkspaceFailed += (_sender, diag) =>
		{
			if (diag.Diagnostic.Kind == WorkspaceDiagnosticKind.Warning)
			{
				Console.WriteLine($"MSBuildWorkspace warning: {diag.Diagnostic}");
			}
			else
			{
				taskCompletionSource.TrySetException(new InvalidOperationException($"Failed to create MSBuildWorkspace: {diag.Diagnostic}"));
			}
		};

		var currentSolution = workspace.CurrentSolution;
		var references = BuildFrameworkReferences();

		foreach(var projectName in _additionalFiles.Keys.Concat(_sourceFiles.Keys).Distinct())
		{
			var projectInfo = ProjectInfo.Create(
							ProjectId.CreateNewId(),
							VersionStamp.Default,
							name: projectName,
							assemblyName: projectName,
							language: LanguageNames.CSharp,
							filePath: Path.Combine(_baseWorkFolder, projectName + "csproj"),
							outputFilePath: _baseWorkFolder,
							metadataReferences: references);

			projectInfo = projectInfo
				.WithCompilationOutputInfo(
					projectInfo.CompilationOutputInfo.WithAssemblyPath(Path.Combine(_baseWorkFolder, projectName + ".exe")));

			var project = workspace.AddProject(projectInfo);
			currentSolution = project.Solution;

			if (_sourceFiles.TryGetValue(projectName, out var sourceFiles))
			{
				foreach (var (fileName, content) in sourceFiles)
				{
					var documentId = DocumentId.CreateNewId(project.Id);

					currentSolution = currentSolution.AddDocument(
						documentId,
						fileName,
						CSharpSyntaxTree.ParseText(content, encoding: Encoding.UTF8).GetText(),
						filePath: Path.Combine(_baseWorkFolder, project.Name, fileName)
					);
				}
			}

			if (_additionalFiles.TryGetValue(projectName, out var additionalFiles))
			{
				foreach (var (fileName, content) in additionalFiles)
				{
					var documentId = DocumentId.CreateNewId(currentSolution.Projects.First().Id);
					currentSolution = currentSolution.AddAdditionalDocument(
						documentId,
						fileName,
						CSharpSyntaxTree.ParseText(content, encoding: Encoding.UTF8).GetText(),
						filePath: Path.Combine(_baseWorkFolder, project.Name, fileName));
				}
			}
		}

		var generatorReference = new MyGeneratorReference(ImmutableArray.Create<ISourceGenerator>(new XamlGenerator.XamlCodeGenerator()));

		//currentSolution = currentSolution.Projects.First().WithAnalyzerReferences(new[] {
		//	generatorReference
		//}).Solution;

		// Materialize the first build
		foreach (var p in currentSolution.Projects)
		{
			var c = await p.GetCompilationAsync(ct);

			if (c is null)
			{
				throw new InvalidOperationException($"Failed to get the compilation for {p}");
			}

			if (c.GetDiagnostics().Any(d => d.DefaultSeverity == DiagnosticSeverity.Error))
			{
				var errors = c.GetDiagnostics().Where(d => d.DefaultSeverity == DiagnosticSeverity.Error);

				throw new InvalidOperationException($"Compilation errors: {string.Join(",", errors)}");
			}
			
			var emitResult = c.Emit(
				p.CompilationOutputInfo.AssemblyPath!,
				pdbPath: Path.ChangeExtension(p.CompilationOutputInfo.AssemblyPath, ".pdb"));

			if (!emitResult.Success)
			{
				throw new InvalidOperationException($"Emit errors: {string.Join(",", emitResult.Diagnostics)}");
			}
		}

		var metadataUpdateCaps = CapsRaw.Split(" ");
		var hotReloadService = new WatchHotReloadService(workspace.Services, metadataUpdateCaps);
		await hotReloadService.StartSessionAsync(currentSolution, ct);

		_currentSolution = currentSolution;
		_hotReloadService = hotReloadService;
	}

	public async Task<UpdateResult> Update()
	{
		if(_hotReloadService is null || _currentSolution is null)
		{
			throw new InvalidOperationException($"Initialize must be called before Update");
		}

		var (updates, diagnostics) = await _hotReloadService.EmitSolutionUpdateAsync(_currentSolution, CancellationToken.None);

		return new(diagnostics, updates);
	}

	private static PortableExecutableReference[] BuildFrameworkReferences() => Directory.GetFiles(Path.GetDirectoryName(typeof(object).Assembly.Location)!, "System*.dll")
				.Where(f => !f.Contains(".Native", StringComparison.OrdinalIgnoreCase))
				.Select(f => MetadataReference.CreateFromFile(f))
				.ToArray();
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
