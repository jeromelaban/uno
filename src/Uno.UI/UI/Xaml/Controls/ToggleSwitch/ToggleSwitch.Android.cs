namespace Microsoft.UI.Xaml.Controls
{
	public partial class ToggleSwitch
	{
		partial void OnLoadedNative()
		{
			Clickable = true;
			Focusable = true;
			FocusableInTouchMode = true;
		}
	}
}
