#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;

namespace Microsoft.UI.Xaml
{
	public sealed partial class SetterBaseCollection : DependencyObjectCollection<SetterBase>
	{
		public SetterBaseCollection()
		{

		}

		internal SetterBaseCollection(DependencyObject parent, bool isAutoPropertyInheritanceEnabled) 
			: base(parent, isAutoPropertyInheritanceEnabled: false)
		{
		}
	}
}
