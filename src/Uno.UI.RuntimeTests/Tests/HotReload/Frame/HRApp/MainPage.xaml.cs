using System.Diagnostics;
using System.IO;
using Uno.UI.RemoteControl;
using Uno.UI.RemoteControl.HotReload;

namespace UnoApp50
{
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();

			if (Environment.GetCommandLineArgs().Contains("--uitest"))
			{
				_ = RunUITests();
			}
		}

		private async Task RunUITests()
		{
			Debugger.Launch();

			RemoteControlClient.Initialize(typeof(App));

			if (RemoteControlClient.Instance is not null)
			{
				await RemoteControlClient.Instance.WaitForConnection();
				await RemoteControlClient.Instance.RegisteredProcessors
					.OfType<ClientHotReloadProcessor>()
					.First()
					.HotReloadWorkspaceLoaded;
			}

			await testControl.RunTests(CancellationToken.None, new());

			// get the first command line argument after `--uitest`
			var testResultPath = Environment.GetCommandLineArgs().SkipWhile(a => a != "--uitest").Skip(1).FirstOrDefault();

			if (testResultPath is not null)
			{
				File.WriteAllText(testResultPath, testControl.NUnitTestResultsDocument);
			}

			// Application.Current.Exit();
		}
	}
}
