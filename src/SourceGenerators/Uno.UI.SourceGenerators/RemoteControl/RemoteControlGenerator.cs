#nullable enable

using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions;
using Uno.Roslyn;
using Uno.UI.SourceGenerators.Helpers;

#if NETFRAMEWORK
using Uno.SourceGeneration;
#endif

namespace Uno.UI.SourceGenerators.RemoteControl
{
	[Generator]
	public class RemoteControlGenerator : ISourceGenerator
	{
		public void Initialize(GeneratorInitializationContext context)
		{
			DependenciesInitializer.Init();
		}

		public void Execute(GeneratorExecutionContext context)
		{
			if (
				!DesignTimeHelper.IsDesignTime(context)
				&& context.GetMSBuildPropertyValue("Configuration") == "Debug"
				&& IsRemoteControlClientInstalled(context)
				&& IsApplication(context))
			{
				var sb = new IndentedStringBuilder();

				sb.AppendLineInvariant("// <auto-generated>");
				sb.AppendLineInvariant("// ***************************************************************************************");
				sb.AppendLineInvariant("// This file has been generated by the package Uno.UI.RemoteControl - for Xaml Hot Reload.");
				sb.AppendLineInvariant("// Documentation: https://platform.uno/docs/articles/features/working-with-xaml-hot-reload.html");
				sb.AppendLineInvariant("// ***************************************************************************************");
				sb.AppendLineInvariant("// </auto-generated>");
				sb.AppendLineInvariant("// <autogenerated />");
				sb.AppendLineInvariant("#pragma warning disable // Ignore code analysis warnings");

				sb.AppendLineInvariant("");

				BuildEndPointAttribute(context, sb);
				BuildSearchPaths(context, sb);
				BuildServerProcessorsPaths(context, sb);

				context.AddSource("RemoteControl", sb.ToString());
			}
		}

		private void BuildServerProcessorsPaths(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			sb.AppendLineInvariant($"[assembly: global::Uno.UI.RemoteControl.ServerProcessorsConfigurationAttribute(" +
				$"@\"{context.GetMSBuildPropertyValue("UnoRemoteControlProcessorsPath")}\"" +
				$")]");
		}

		private static bool IsRemoteControlClientInstalled(GeneratorExecutionContext context)
			=> context.Compilation.GetTypeByMetadataName("Uno.UI.RemoteControl.RemoteControlClient") != null;

		private static void BuildSearchPaths(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			sb.AppendLineInvariant($"[assembly: global::Uno.UI.RemoteControl.ProjectConfigurationAttribute(");
			sb.AppendLineInvariant($"@\"{context.GetMSBuildPropertyValue("MSBuildProjectFullPath")}\",\n");

			var msBuildProjectDirectory = context.GetMSBuildPropertyValue("MSBuildProjectDirectory");
			var sources = new[] {
					"Page",
					"ApplicationDefinition",
					"ProjectReference",
				};

			IEnumerable<string> BuildSearchPath(string s)
				=> context
					.GetMSBuildItems(s)
					.Select(v => Path.IsPathRooted(v.Identity) ? v.Identity : Path.Combine(msBuildProjectDirectory, v.Identity));

			var xamlPaths = from item in sources.SelectMany(BuildSearchPath)
							select Path.GetDirectoryName(item);

			var distictPaths = string.Join(",\n", xamlPaths.Distinct().Select(p => $"@\"{p}\""));

			sb.AppendLineInvariant("{0}", $"new string[]{{{distictPaths}}}");

			sb.AppendLineInvariant($")]");
		}


		private static void BuildEndPointAttribute(GeneratorExecutionContext context, IndentedStringBuilder sb)
		{
			var unoRemoteControlPort = context.GetMSBuildPropertyValue("UnoRemoteControlPort");

			if (string.IsNullOrEmpty(unoRemoteControlPort))
			{
				unoRemoteControlPort = "0";
			}

			var unoRemoteControlHost = context.GetMSBuildPropertyValue("UnoRemoteControlHost");

			if (string.IsNullOrEmpty(unoRemoteControlHost))
			{
				var addresses = NetworkInterface.GetAllNetworkInterfaces()
					.SelectMany(x => x.GetIPProperties().UnicastAddresses)
					.Where(x => !IPAddress.IsLoopback(x.Address));

				foreach (var addressInfo in addresses)
				{
					sb.AppendLineInvariant($"[assembly: global::Uno.UI.RemoteControl.ServerEndpointAttribute(\"{addressInfo.Address}\", {unoRemoteControlPort})]");
				}
			}
			else
			{
				sb.AppendLineInvariant($"[assembly: global::Uno.UI.RemoteControl.ServerEndpointAttribute(\"{unoRemoteControlHost}\", {unoRemoteControlPort})]");
			}
		}

		private bool IsApplication(GeneratorExecutionContext context)
		{
			var isAndroidApp = context.GetMSBuildPropertyValue("AndroidApplication")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;
			var isiOSApp = context.GetMSBuildPropertyValue("ProjectTypeGuidsProperty")?.Equals("{FEACFBD2-3405-455C-9665-78FE426C6842},{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}", StringComparison.OrdinalIgnoreCase) ?? false;
			var ismacOSApp = context.GetMSBuildPropertyValue("ProjectTypeGuidsProperty")?.Equals("{A3F8F2AB-B479-4A4A-A458-A89E7DC349F1},{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}", StringComparison.OrdinalIgnoreCase) ?? false;
			var isExe = context.GetMSBuildPropertyValue("OutputType")?.Equals("Exe", StringComparison.OrdinalIgnoreCase) ?? false;
			var isUnoHead = context.GetMSBuildPropertyValue("IsUnoHead")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

			return isAndroidApp
				|| (isiOSApp && isExe)
				|| (ismacOSApp && isExe)
				|| isUnoHead;
		}
	}
}

