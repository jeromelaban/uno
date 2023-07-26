using System.IO;

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
			await testControl.RunTests(CancellationToken.None, new());

			// get the first command line argument after `--uitest`
			var testResultPath = Environment.GetCommandLineArgs().SkipWhile(a => a != "--uitest").Skip(1).FirstOrDefault();

			if (testResultPath is not null)
			{
				File.WriteAllText(testResultPath, testControl.NUnitTestResultsDocument);
			}
		}
	}
}
