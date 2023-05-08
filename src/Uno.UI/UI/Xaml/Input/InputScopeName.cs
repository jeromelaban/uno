using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Input
{
	[ContentProperty(Name = nameof(NameValue))]
	public partial class InputScopeName
	{
		public InputScopeName()
		{

		}

		public InputScopeName(InputScopeNameValue value)
		{
			NameValue = value;
		}
		public InputScopeNameValue NameValue { get; set; }
	}
}
