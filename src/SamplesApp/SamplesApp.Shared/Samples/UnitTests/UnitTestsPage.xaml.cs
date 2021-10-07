using System.Reflection;
using Microsoft.UI.Xaml;
using Uno.UI.Samples.Controls;
using Microsoft.UI.Xaml.Controls;

namespace SamplesApp.Samples.UnitTests
{
	[SampleControlInfo("Unit Tests", "Unit Tests Runner", ignoreInSnapshotTests: true)]
	public sealed partial class UnitTestsPage : Page
	{
		public UnitTestsPage()
		{
			this.InitializeComponent();

			// Manually load the runtime tests assembly
			Assembly.Load("Uno.UI.RuntimeTests");

#if __WASM__
			var t = typeof(SamplesApp.UnitTests.TSBindings.TSBindingsTests);
#endif
		}
	}
}
