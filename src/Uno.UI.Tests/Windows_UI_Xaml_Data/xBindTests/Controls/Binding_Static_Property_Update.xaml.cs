using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Uno.UI.Tests.Windows_UI_Xaml_Data.xBindTests.Controls;

public sealed partial class Binding_Static_Property_Update : Page
{
	public Binding_Static_Property_Update()
	{
		this.InitializeComponent();
	}
}

public static class Binding_Static_Property_Update_Class
{
	public static Binding_Static_Property_Update_Class2 VM { get; private set; } = new();
}

public class Binding_Static_Property_Update_Class2 : System.ComponentModel.INotifyPropertyChanged
{
	private string _myProperty = "41";

	public string MyProperty
	{
		get => _myProperty;
		set
		{
			_myProperty = value;
			PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(MyProperty)));
		}
	}

	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
}
