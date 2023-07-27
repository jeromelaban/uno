#nullable enable

using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Uno.Foundation.Logging;
using Windows.UI.Xaml;
using Uno.UI.RemoteControl;
using Windows.UI.Xaml.Tests.Common;
using Windows.UI.Composition;
using System.Threading;

namespace Uno.UI.RuntimeTests.Tests.HotReload;

[TestClass]
internal class Given_HotReloadWorkspace
{
	private static Process? _process;
	private static int _remoteControlPort;
	private static Process? _testAppProcess;

	[TestInitialize]
	public async Task Initialize()
	{
		await InitializeServer();
		await BuildTestApp();
	}

	[TestCleanup]
	public async Task TestCleanupWrapper()
	{
		_testAppProcess?.Kill();
	}

	[TestMethod]
	public async Task When_HotReloadScenario()
	{
		await RunTestApp(CancellationToken.None);
	}

#if DEBUG
	private const string Configuration = "Debug";
#else
	private const string Configuration = "Release";
#endif

	public static async Task InitializeServer()
	{
		if (RemoteControlClient.Instance is null)
		{
			_remoteControlPort = GetTcpPort();

			StartServer(_remoteControlPort);
		}
	}

	public static async Task<string> RunTestApp(CancellationToken ct)
	{
		var testOutput = Path.GetTempFileName();

		var hrAppPath = GetHotReloadAppPath();

		var p = await RunProcess(
			ct,
			"dotnet",
			new() {
				"run",
				"--no-build",
				"--uitest",
				testOutput
			},
			hrAppPath,
			"HRApp",
			true
		);

		_testAppProcess = p;

		if (p.ExitCode != 0)
		{
			throw new InvalidOperationException("Failed to run HR app");
		}

		return testOutput;
	}

	private static async Task<Process> RunProcess(
		CancellationToken ct,
		string executable,
		List<string> parameters,
		string workingDirectory,
		string logPrefix,
		bool waitForExit)
	{
		var process = StartProcess(executable, parameters, workingDirectory, logPrefix, waitForExit);

		await process.WaitForExitAsync();

		return process;
	}

	private static Process StartProcess(
		string executable,
		List<string> parameters,
		string workingDirectory,
		string logPrefix,
		bool waitForExit)
	{
		var hrAppPath = GetHotReloadAppPath();

		var pi = new ProcessStartInfo(executable)
		{
			UseShellExecute = false,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden,
			WorkingDirectory = workingDirectory,
		};

		foreach (var parm in parameters)
		{
			pi.ArgumentList.Add(parm);
		}

		// redirect the output
		pi.RedirectStandardOutput = true;
		pi.RedirectStandardError = true;

		var process = new System.Diagnostics.Process();

		// hookup the event handlers to capture the data that is received
		process.OutputDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Debug(logPrefix + ": " + args.Data ?? "");
		process.ErrorDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Error(logPrefix + ": " + args.Data ?? "");

		process.StartInfo = pi;
		process.Start();

		// start our event pumps
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();

		return process;
	}

	public static async Task BuildTestApp()
	{
		var hrAppPath = GetHotReloadAppPath();

		var pi = new ProcessStartInfo("dotnet")
		{
			UseShellExecute = false,
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Normal,
			WorkingDirectory = hrAppPath,
			ArgumentList =
			{
				"build",
				$"-p:UnoRemoteControlPort={_remoteControlPort}",
				$"-p:UnoRemoteControlHost=127.0.0.1",
				"--configuration",
				Configuration,
			}
		};

		// redirect the output
		pi.RedirectStandardOutput = true;
		pi.RedirectStandardError = true;

		var process = new System.Diagnostics.Process();

		// hookup the eventhandlers to capture the data that is received
		process.OutputDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Debug(args.Data ?? "");
		process.ErrorDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Error(args.Data ?? "");

		process.StartInfo = pi;
		process.Start();

		// start our event pumps
		process.BeginOutputReadLine();
		process.BeginErrorReadLine();

		await process.WaitForExitAsync();

		if (process.ExitCode != 0)
		{
			throw new InvalidOperationException("Failed to build app");
		}
	}

	private static string GetHotReloadAppPath()
	{
		var basePath = Path.GetDirectoryName(Application.Current.GetType().Assembly.Location)!;
		var hrAppPath = Path.Combine(basePath, "..", "..", "..", "..", "..", "Uno.UI.RuntimeTests", "Tests", "HotReload", "Frame", "HRApp");
		return hrAppPath;
	}

	private static void StartServer(int port)
	{
		if (_process?.HasExited ?? true)
		{
			var version = GetDotnetMajorVersion();
			var runtimeVersionPath = version <= 5 ? "netcoreapp3.1" : $"net{version}.0";

			var basePath = Path.GetDirectoryName(Application.Current.GetType().Assembly.Location)!;
			var toolsPath = Path.Combine(basePath, "..", "..", "..", "..", "..", "Uno.UI.RemoteControl.Host", "bin", Configuration);

			var sb = new StringBuilder();

			var hostBinPath = Path.Combine(toolsPath, runtimeVersionPath, "Uno.UI.RemoteControl.Host.dll");

			if (!File.Exists(hostBinPath))
			{
				throw new InvalidOperationException($"Unable to find {hostBinPath}");
			}

			string arguments = $"\"{hostBinPath}\" --httpPort {port} --ppid {Process.GetCurrentProcess().Id} --metadata-updates true";
			var pi = new ProcessStartInfo("dotnet", arguments)
			{
				UseShellExecute = false,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Hidden,
				WorkingDirectory = Path.Combine(toolsPath),
			};

			// redirect the output
			pi.RedirectStandardOutput = true;
			pi.RedirectStandardError = true;

			_process = new System.Diagnostics.Process();

			// hookup the eventhandlers to capture the data that is received
			_process.OutputDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Debug(args.Data ?? "");
			_process.ErrorDataReceived += (sender, args) => typeof(RemoteControlServerHelper).Log().Error(args.Data ?? "");

			_process.StartInfo = pi;
			_process.Start();

			// start our event pumps
			_process.BeginOutputReadLine();
			_process.BeginErrorReadLine();
		}
	}

	private static int GetDotnetMajorVersion()
	{
		if (Application.Current.GetType().Assembly.Location is { Length: 0 })
		{
			throw new InvalidOperationException("The Application location must have a physical path location");
		}

		var result = ProcessHelpers.RunProcess("dotnet", "--version", Path.GetDirectoryName(Application.Current.GetType().Assembly.Location));

		if (result.exitCode != 0)
		{
			throw new InvalidOperationException($"Unable to detect current dotnet version (\"dotnet --version\" exited with code {result.exitCode})");
		}

		if (result.output.Contains("."))
		{
			if (int.TryParse(result.output.Substring(0, result.output.IndexOf('.')), out int majorVersion))
			{
				return majorVersion;
			}
		}

		throw new InvalidOperationException($"Unable to detect current dotnet version (\"dotnet --version\" returned \"{result.output}\")");
	}

	private static int GetTcpPort()
	{
		var l = new TcpListener(IPAddress.Loopback, 0);
		l.Start();
		var port = ((IPEndPoint)l.LocalEndpoint).Port;
		l.Stop();
		return port;
	}
}
