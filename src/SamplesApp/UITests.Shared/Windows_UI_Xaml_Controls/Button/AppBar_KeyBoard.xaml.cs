using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Uno.UI.Samples.Content.UITests.ButtonTestsControl
{
	[SampleControlInfo("ButtonTestsControl", "AppBar_KeyBoard")]
	public sealed partial class AppBar_KeyBoard : UserControl
	{
		public AppBar_KeyBoard()
		{
			this.InitializeComponent();
		}

		private void OnCommandBarButtonClick(object sender, RoutedEventArgs args)
		{
			var _ = new Windows.UI.Popups.MessageDialog("CommandBar Button Clicked").ShowAsync();
		}
	}
}
