using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uno.Extensions;

namespace Windows.UI.Xaml
{
	public partial class ElementStub
	{
		static ElementStub()
		{
			VisibilityProperty.OverrideMetadata(
				forType: typeof(ElementStub),
				typeMetadata: new FrameworkPropertyMetadata(defaultValue: Visibility.Collapsed)
			);
		}

		private FrameworkElement MaterializeContent()
		{
			if (Parent is FrameworkElement parentElement)
			{
				var currentPosition = parentElement.GetChildren().IndexOf(this);

				if (currentPosition != -1)
				{
					var newContent = ContentBuilder() as UIElement;

					parentElement.RemoveChild(this);

					parentElement.AddChild(newContent, currentPosition);
				}
			}

			return null;
		}
	}
}
