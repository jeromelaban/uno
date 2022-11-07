using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Extensions;
using Uno.UI.RemoteControl.Host.HotReload.MetadataUpdates;
using Uno.UI.SourceGenerators.MetadataUpdates;

namespace Uno.UI.SourceGenerators.Tests.MetadataUpdateTests;

[TestClass]
public class Given_HotReloadService
{
	//[TestMethod]
	//public async Task When_Empty()
	//{
	//	TaskCompletionSource<(Solution, WatchHotReloadService)> tcs = new();
	//	Reporter reporter = new();

	//	await HotReloadWorkspaceProvider.CreateProject(
	//		tcs,
	//		reporter,
	//		new HotReloadWorkspaceProvider.Document[0],
	//		new HotReloadWorkspaceProvider.Document[0],
	//		CancellationToken.None);

	//	var result = await tcs.Task;
	//}

	//[TestMethod]
	//public async Task When_Single_Code_File()
	//{
	//	TaskCompletionSource<(Solution solution, WatchHotReloadService service)> tcs = new();
	//	Reporter reporter = new();

	//	await HotReloadWorkspaceProvider.CreateProject(
	//		tcs,
	//		reporter,
	//		new HotReloadWorkspaceProvider.Document[] { new("test.cs", "public static class Program { public static void Main() { } }") },
	//		new HotReloadWorkspaceProvider.Document[0],
	//		CancellationToken.None);

	//	var result = await tcs.Task;

	//	Assert.IsNotNull(result.solution);
	//	Assert.IsNotNull(result.service);
	//	Assert.AreEqual(1, result.solution.Projects.Count());
	//	Assert.AreEqual(1, result.solution.Projects.First().Documents.Count());
	//}

	//[TestMethod]
	//public async Task When_Single_Code_File_With_No_Update()
	//{
	//	TaskCompletionSource<(Solution solution, WatchHotReloadService service)> tcs = new();
	//	Reporter reporter = new();

	//	await HotReloadWorkspaceProvider.CreateProject(
	//		tcs,
	//		reporter,
	//		new HotReloadWorkspaceProvider.Document[] { new("test.cs", "public static class Program { public static void Main() { } }") },
	//		new HotReloadWorkspaceProvider.Document[0],
	//		CancellationToken.None);

	//	var result = await tcs.Task;

	//	Assert.IsNotNull(result.solution);
	//	Assert.IsNotNull(result.service);
	//	Assert.AreEqual(1, result.solution.Projects.Count());
	//	Assert.AreEqual(1, result.solution.Projects.First().Documents.Count());

	//	var updateResult = await result.service.EmitSolutionUpdateAsync(result.solution, CancellationToken.None);

	//	Assert.AreEqual(0, updateResult.diagnostics.Length);
	//}

	[TestMethod]
	public async Task When_Single_Code_File_With_Code_Update()
	{
		TaskCompletionSource<(AdhocWorkspace solution, WatchHotReloadService service)> tcs = new();
		Reporter reporter = new();

		await HotReloadWorkspaceProvider.CreateProject(
			tcs,
			reporter,
			new HotReloadWorkspaceProvider.Document[] { new("test.cs", "public static class Program { public static void Main() { } }") },
			new HotReloadWorkspaceProvider.Document[0],
			CancellationToken.None);

		var result = await tcs.Task;

		Assert.IsNotNull(result.solution);
		Assert.IsNotNull(result.service);
		Assert.AreEqual(1, result.solution.CurrentSolution.Projects.Count());
		Assert.AreEqual(1, result.solution.CurrentSolution.Projects.First().Documents.Count());

		var project = result.solution.CurrentSolution.Projects.First();
		var doc = project.Documents.First();

		var solution = result.solution.CurrentSolution.WithDocumentText(
			doc.Id,
			CSharpSyntaxTree.ParseText(
				"public static class Program { public static void Main() { System.Console.WriteLine(); } }",
				encoding: Encoding.UTF8).GetText(), PreservationMode.PreserveIdentity);

		File.WriteAllText(doc.FilePath!, "public static class Program { public static void Main() { System.Console.WriteLine(); } }", Encoding.UTF8);

		result.solution.TryApplyChanges(solution);

		var updateResult = await result.service.EmitSolutionUpdateAsync(result.solution.CurrentSolution, CancellationToken.None);

		Assert.AreEqual(0, updateResult.diagnostics.Length);
		Assert.AreEqual(1, updateResult.updates.Length);
	}

}
