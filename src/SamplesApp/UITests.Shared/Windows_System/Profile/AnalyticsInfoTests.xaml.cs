using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uno.UI.Samples.Controls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace UITests.Shared.Windows_System.Profile
{
	[SampleControlInfo("Windows.System", "Profile.AnalyticsInfo",
		   description: "Shows properties of AnalyticsInfo")]
	public sealed partial class AnalyticsInfoTests : UserControl
    {
        public AnalyticsInfoTests()
        {
            this.InitializeComponent();
            DeviceFormTextBlock.Text = AnalyticsInfo.DeviceForm;
            DeviceFamilyTextBlock.Text = AnalyticsInfo.VersionInfo.DeviceFamily;
            DeviceFamilyVersionTextBlock.Text = AnalyticsInfo.VersionInfo.DeviceFamilyVersion;
        }
    }
}
