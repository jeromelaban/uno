using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uno.Extensions;
using Uno.UI.RemoteControl.Host.HotReload.MetadataUpdates;
using Uno.UI.SourceGenerators.MetadataUpdates;

namespace Uno.UI.SourceGenerators.Tests.MetadataUpdateTests;

[TestClass]
public class Given_HotReloadService
{
	[TestMethod]
	public async Task When_Empty()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);
	}

	[TestMethod]
	public async Task When_Single_Code_File_With_No_Update()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Single_Code_File_With_No_Update_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Single_Code_File_With_Code_Update()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Single_Code_File_With_Code_Update_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_With_ThemeResource_Add()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_With_ThemeResource_Add_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_No_Update()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_Text_Change()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_Text_Change_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Add()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Add_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(1, results[0].Diagnostics.Length);
		Assert.IsTrue(results[0].Diagnostics.First().ToString().Contains("ENC0100"));
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Change()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(1, results[0].Diagnostics.Length);
		Assert.IsTrue(results[0].Diagnostics.First().ToString().Contains("ENC0009")); // Updating the type of property requires restarting the application.
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Change_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		Assert.AreEqual(1, results[0].Diagnostics.Length);
		Assert.IsTrue(results[0].Diagnostics.First().ToString().Contains("ENC0009")); // Updating the type of property requires restarting the application.
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Add_Twice_Release()
	{
		var results = await ApplyScenario(isDebugCompilation: false, isMono: false);

		Assert.AreEqual(2, results.Length);
		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
		Assert.AreEqual(4, results[1].Diagnostics.Length);
		Assert.IsTrue(results[1].Diagnostics.First().ToString().Contains("ENC0049"));
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Single_xName_Add_Twice_Debug()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(2, results.Length);
		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
		Assert.AreEqual(0, results[1].Diagnostics.Length);
		Assert.AreEqual(1, results[1].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_xBind_Event_Add()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Add_xBind_Simple_Property()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Add_xBind_Simple_Property_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		// error ENC0100: Adding auto-property requires restarting the application.	
		// error ENC0100: Adding field requires restarting the application.

		Assert.AreEqual(2, results[0].Diagnostics.Length);
		Assert.IsTrue(results[0].Diagnostics[0].ToString().Contains("ENC0100"));
		Assert.IsTrue(results[0].Diagnostics[1].ToString().Contains("ENC0100"));
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Add_xBind_Simple_Property_Update()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		// MainPage_c2bc688a73eab5431d787dcd21fe32b9.cs(68,83): error ENC0049: Ceasing to capture variable '__that' requires restarting the application.
		Assert.AreEqual(1, results[0].Diagnostics.Length);
		Assert.IsTrue(results[0].Diagnostics[0].ToString().Contains("ENC0049"));
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	[DataTestMethod]

	public async Task When_Simple_Xaml_Add_xBind_Simple_Property_Update_Mono()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: true);

		// MainPage_c2bc688a73eab5431d787dcd21fe32b9.cs(68,83): error ENC0049: Ceasing to capture variable '__that' requires restarting the application.
		Assert.AreEqual(1, results[0].Diagnostics.Length);
		Assert.AreEqual("ENC0049", results[0].Diagnostics[0].Id);
		Assert.AreEqual(0, results[0].MetadataUpdates.Length);
	}

	[TestMethod]
	public async Task When_Simple_Xaml_Add_xLoad()
	{
		var results = await ApplyScenario(isDebugCompilation: true, isMono: false);

		Assert.AreEqual(0, results[0].Diagnostics.Length);
		Assert.AreEqual(1, results[0].MetadataUpdates.Length);
	}

	[DataTestMethod]
	[DynamicData(nameof(GetScenarios), DynamicDataSourceType.Method)]
	public async Task TestRunner(string name, Scenario scenario)
	{
		var results = await ApplyScenario(scenario.IsDebug, scenario.IsMono, name);

		for (int i = 0; i < scenario.PassResults.Length; i++)
		{
			var resultValidation = scenario.PassResults[i];

			Assert.AreEqual(resultValidation.Diagnostics.Length, results[i].Diagnostics.Length);
			Assert.AreEqual(resultValidation.MetadataUpdates, results[i].MetadataUpdates.Length);
		}
	}

	public record Scenario(bool IsDebug, bool IsMono, params PassResult[] PassResults);
	public record PassResult(int MetadataUpdates, params DiagnosticsResult[] Diagnostics);
	public record DiagnosticsResult(string Id);

	private static IEnumerable<object?[]> GetScenarios()
	{
		foreach(var scenarioFolder in Directory.EnumerateDirectories(ScenariosFolder, "*.*", SearchOption.TopDirectoryOnly))
		{
			var scenarioName = Path.GetFileName(scenarioFolder);
			var path = Path.Combine(scenarioFolder, "Scenario.json");

			if (!File.Exists(path))
			{
				Assert.Fail($"Unable to find TestDetails.json for {scenarioName}");
			}

			var detailsContent = File.ReadAllText(path);

			var scenarios = System.Text.Json.JsonSerializer.Deserialize<Scenario[]>(detailsContent);
			if (scenarios != null)
			{
				foreach (var scenario in scenarios)
				{
					yield return new object?[] {
						scenarioName,
						scenario
					};
				}
			}			
		}
	}

	private static string ScenariosFolder
		=> Path.Combine(
			Path.GetDirectoryName(typeof(HotReloadWorkspace).Assembly.Location)!,
			"MetadataUpdateTests",
			"Scenarios");

	private async Task<HotReloadWorkspace.UpdateResult[]> ApplyScenario(bool isDebugCompilation, bool isMono, [CallerMemberName] string? name = null)
	{
		if(name is null)
		{
			throw new InvalidOperationException($"A test scenario name must be provided.");
		}

		name = name
			.Replace("_Debug", "")
			.Replace("_Release", "")
			.Replace("_Mono", "");

		var scenarioFolder = Path.Combine(ScenariosFolder, name);
		
		HotReloadWorkspace SUT = new(isDebugCompilation, isMono);
		List<HotReloadWorkspace.UpdateResult> results = new();

		var steps = Directory
			.GetFiles(scenarioFolder, "*.*", SearchOption.AllDirectories)
			.OrderBy(f => f)
			.GroupBy(f => Path.GetRelativePath(scenarioFolder, f).Split(Path.DirectorySeparatorChar)[0]);

		int index = 0;
		foreach (var step in steps)
		{
			foreach (var file in step)
			{
				var pathParts = Path.GetRelativePath(scenarioFolder, file).Split(Path.DirectorySeparatorChar);
				
				var fileContent = File.ReadAllText(file);

				if (Path.GetExtension(file) == ".cs")
				{
					SUT.SetSourceFile(pathParts[1], pathParts[2], fileContent);
				}
				else
				{
					SUT.SetAdditionalFile(pathParts[1], pathParts[2], fileContent);
				}
			}

			if(index++ == 0)
			{
				await SUT.Initialize(CancellationToken.None);
			}
			else
			{
				results.Add(await SUT.Update());
			}
		}
		
		return results.ToArray();
	}
}
