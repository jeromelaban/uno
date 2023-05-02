#nullable enable
using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;

namespace UnoWinUIRevert
{
	class Program
	{
		static void Main(string[] args)
		{
			var basePath = args[0];

			DeleteFolder(Path.Combine(basePath, "src", "Uno.UI", "Generated"));
			DeleteFolder(Path.Combine(basePath, "src", "Uno.UI.Composition", "Generated"));
			DeleteFolder(Path.Combine(basePath, "src", "Uno.UWP", "Generated"));
			DeleteFolder(Path.Combine(basePath, "src", "Uno.UI", "tsBindings")); // Generated

			var colorsFilepath = Path.Combine(basePath, @"src", "Uno.UI", "UI", "Colors.cs");
			if (File.Exists(colorsFilepath))
			{
				File.Delete(colorsFilepath);
			}

			var colorHelperFilePath = Path.Combine(basePath, @"src", "Uno.UI", "UI", "ColorHelper.cs");
			if (File.Exists(colorHelperFilePath))
			{
				File.Delete(colorHelperFilePath);
			}

			var fontWeightsFilePath = Path.Combine(basePath, @"src", "Uno.UI", "UI", "Text", "FontWeights.cs");
			if (File.Exists(fontWeightsFilePath))
			{
				File.Delete(fontWeightsFilePath);
			}

			var inputPath = Path.Combine(basePath, "src", "Uno.UI", "UI", "Input");
			if (Directory.Exists(inputPath))
			{
				Directory.Delete(inputPath, true);
			}

			var dispatcherQueuePath = Path.Combine(basePath, "src", "Uno.UI.Dispatching", "Dispatching");
			if (Directory.Exists(dispatcherQueuePath))
			{
				Directory.Delete(dispatcherQueuePath, true);
			}

			// Replace microsoft namespaces in a reversible way
			ReplaceInFolders(basePath,
				new[] {
				("Microsoft/* UWP don't rename */.UI.Xaml", "Microsoft/* UWP don't rename */.UI.Xaml") }
				, searchPattern: "*.cs"
			);

			// Ensure that files in the Microsoft namespace are not renamed, as they need to be kept in this specific namespace
			ReplaceInFolders(
				Path.Combine(basePath, @"src", "Uno.UI", "Microsoft"),
				new[] {
					("namespace Microsoft.UI.Xaml", "namespace Microsoft/**/.UI.Xaml"),
					("namespace Microsoft.UI.Private.Controls", "namespace Microsoft/**/.UI.Private.Controls"),
					("Microsoft.UI.Xaml.Controls._Tracing", "Microsoft/**/.UI.Xaml.Controls._Tracing"),
				});

			// Generic replacements
			var genericReplacements = new[] {
				("Microsoft.UI.Xaml", "Microsoft/* UWP don't rename */.UI.Xaml"),
				("Microsoft.UI.Composition", "Windows.UI.Composition"),
				("Microsoft.UI.Colors", "Windows.UI.Colors"),
				("Microsoft.UI.Text.FontWeights", "Windows.UI.Text.FontWeights"),
				("Microsoft.UI.ColorHelper", "Windows.UI.ColorHelper"),
				("Microsoft.UI.Xaml", "Windows.UI.Xaml"),
				("__LinkerHints.Is_Microsoft_UI_Xaml", "__LinkerHints.Is_Windows_UI_Xaml"),
				("__LinkerHints.Is_Windows_UI_Xaml_Controls_LayoutPanel_Available", "__LinkerHints.Is_Microsoft_UI_Xaml_Controls_LayoutPanel_Available"),
				("Uno.UI.Controls.Legacy\", \"ProgressRing", "Windows.UI.Xaml.Controls\", \"ProgressRing"),
				("<UNO_UWP_BUILD>false</UNO_UWP_BUILD>", "<UNO_UWP_BUILD>true</UNO_UWP_BUILD>"),
			};

			ReplaceInFolders(basePath, genericReplacements);

			// Restore ProgressRing
			var progressRingReplacements = new[] {
				("Uno.UI.Controls.Legacy", "Windows.UI.Xaml.Controls"),
			};

			ReplaceInFolders(Path.Combine(basePath, @"src", "Uno.UI", "UI", "Xaml", "Controls", "ProgressRing"), progressRingReplacements);
			ReplaceInFile(Path.Combine(basePath, @"src", "Uno.UI", "UI", "Xaml", "Controls", "ProgressRing", "ProgressRing.xaml"), "\"legacy:ProgressRing\"", "\"ProgressRing\"");
			ReplaceInFile(Path.Combine(basePath, @"src", "Uno.UI", "UI", "Xaml", "Style", "Generic", "Generic.Native.xaml"), "legacy:ProgressRing", "ProgressRing");
			ReplaceInFile(Path.Combine(basePath, @"src", "Uno.UI", "Microsoft", "UI", "Xaml", "Controls", "ProgressRing", "ProgressRing.xaml"), "using:Uno.UI.Controls.Legacy", "using:Microsoft.UI.Xaml.Controls");

			ReplaceInFile(Path.Combine(basePath, @"src", "SourceGenerators", "Uno.UI.SourceGenerators", "XamlGenerator", "XamlConstants.cs"), "Microsoft.UI", "Windows.UI");
			ReplaceInFile(Path.Combine(basePath, @"src", "Uno.UI", "UI", "Xaml", "Markup", "Reader", "XamlConstants.cs"), "Microsoft.UI", "Windows.UI");

			// Restore MUX-only
			ReplaceInFolders(basePath,
				new[] {
					("/* uwp don't rename */\"Windows.UI.Xaml", "/* uwp don't rename */\"Microsoft.UI.Xaml")
					("/* uwp don't rename */\"using:Windows.UI.Xaml", "/* uwp don't rename */\"using:Microsoft.UI.Xaml")
				}
				, searchPattern: "*.cs"
			);

			// Restore MUX-only
			ReplaceInFolders(basePath,
				new[] {
					("/* uwp don't rename */\"Windows.UI.Xaml", "/* uwp don't rename */\"Microsoft.UI.Xaml")
					("/* uwp don't rename */\"using:Windows.UI.Xaml", "/* uwp don't rename */\"using:Microsoft.UI.Xaml")
				}
				, searchPattern: "*.cs"
			);

			UncommentWinUISpecificBlock(Path.Combine(basePath, "build", "Uno.WinUI.nuspec"));
		}

		static string[] _exclusions = new string[] {
			"Uno.UWPSyncGenerator.Reference.csproj",
			"SamplesApp.UWP.csproj",
			"SamplesApp.UWP.Design.csproj",
			@"Uno.UWPSyncGenerator\Generator.cs",
			@"src\Uno.UWP\",
			@"src\Uno.UI\UI\Xaml\Controls\NavigationView\",
			@"src\Uno.UI.RuntimeTests\Tests\Windows_UI_Xaml_Controls\Given_NavigationView.cs",
			@"\obj\",
			@"\bin\",
			@"\.git",
			@"\.vs",
		}
		.Select(AlignPath)
		.ToArray();

		private static string AlignPath(string p) => p.Replace('\\', Path.DirectorySeparatorChar);

		private static void ReplaceInFolders(string basePath, (string from, string to)[] replacements, string searchPattern = "*.*")
		{
			foreach (var file in Directory.EnumerateFiles(basePath, searchPattern, SearchOption.AllDirectories))
			{
				if (_exclusions.Any(e => file.Contains(e, StringComparison.OrdinalIgnoreCase)))
				{
					continue;
				}

				var updated = false;
				var content = File.ReadAllText(file);

				for (int i = 0; i < replacements.Length; i++)
				{
					if (content.Contains(replacements[i].from))
					{
						content = content.Replace(replacements[i].from, replacements[i].to);
						updated = true;
					}
				}

				if (updated)
				{
					Console.WriteLine($"Updating [{file}]");

					int retry = 3;
					while (retry-- > 0)
					{
						try
						{
							File.WriteAllText(file, content, Encoding.UTF8);
						}
						catch
						{
							System.Threading.Thread.Sleep(500);
						}
					}
				}
			}
		}

		private static void DeleteFolder(string path)
		{
			if (Directory.Exists(path))
			{
				Console.WriteLine($"Deleting {path}");
				Directory.Delete(path, true);
			}
		}

		private static void ReplaceInFile(string filePath, string from, string to)
		{
			Console.WriteLine($"Updating [{filePath}]");

			var txt = File.ReadAllText(filePath);
			txt = txt.Replace(from, to);
			File.WriteAllText(filePath, txt, Encoding.UTF8);
		}

		private static void UncommentWinUISpecificBlock(string nuspecPath)
		{
			ReplaceInFile(nuspecPath, @"<!-- BEGIN UWP-excluded -->", "<!-- WinUI Specific ");
			ReplaceInFile(nuspecPath, @"<!-- END UWP-excluded -->", "-->");
		}
	}
}
