using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class PasswordBox : TextBox
	{
		partial void SetPasswordScope(bool shouldHideText)
		{
			SetSecureTextEntry(shouldHideText);
		}
	}
}
