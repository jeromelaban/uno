using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Uno.UI.Tests.Windows_UI_Xaml.Controls;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ThemeResource_Theme_Changing_Override : Page
{
	public ThemeResource_Theme_Changing_Override()
	{
		this.InitializeComponent();
	}
}

public class ThemeResource_Theme_Changing_Override_Custom : ResourceDictionary
{
	private const string GreenUri = "ms-appx:///Windows_UI_Xaml/Controls/ThemeResource_Theme_Changing_Override_MyColorGreen.xaml";
	private const string RedUri = "ms-appx:///Windows_UI_Xaml/Controls/ThemeResource_Theme_Changing_Override_MyColorRed.xaml";
	private const string BrushUri = "ms-appx:///Windows_UI_Xaml/Controls/ThemeResource_Theme_Changing_Override_MyBrush.xaml";
	private const string AliasUri = "ms-appx:///Windows_UI_Xaml/Controls/ThemeResource_Theme_Changing_Override_MyAlias.xaml";
	private const string ButtonUri = "ms-appx:///Windows_UI_Xaml/Controls/ThemeResource_Theme_Changing_Override_MyButton.xaml";
	private static string ColorUri = string.Empty;

	public ThemeResource_Theme_Changing_Override_Custom()
	{
		ColorUri = ColorUri == RedUri ? GreenUri : RedUri;

		var myBrush = new ResourceDictionary { Source = new Uri(BrushUri) };
		var myAlias = new ResourceDictionary { Source = new Uri(AliasUri) };
		var myButton = new ResourceDictionary { Source = new Uri(ButtonUri) };

		myBrush.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri(ColorUri) });
		myAlias.MergedDictionaries.Add(myBrush);
		myButton.MergedDictionaries.Add(myAlias);

		this.MergedDictionaries.Add(myButton);
	}
}
