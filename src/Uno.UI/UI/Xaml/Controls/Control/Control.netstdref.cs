using Uno.UI.Controls;
using Uno.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.UI.Xaml.Media;
using Uno.Logging;
using System.Drawing;
using System.Linq;
using Uno.Disposables;
using Uno.UI;
using View = Microsoft.UI.Xaml.UIElement;

namespace Microsoft.UI.Xaml.Controls
{
	public partial class Control
	{
		public Control()
		{
			InitializeControl();
		}

		partial void UnregisterSubView()
		{
		}

		partial void RegisterSubView(View child)
		{
		}

		/// <summary>
		/// Gets the first sub-view of this control or null if there is none
		/// </summary>
		internal IFrameworkElement GetTemplateRoot()
		{
			return this.GetChildren()?.FirstOrDefault() as IFrameworkElement;
		}
	}
}
