using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.UI.Xaml.Markup
{
	public partial class MarkupExtension : IMarkupExtensionOverrides
	{
		object IMarkupExtensionOverrides.ProvideValue()
		{
			return ProvideValue();
		}
	}
}
