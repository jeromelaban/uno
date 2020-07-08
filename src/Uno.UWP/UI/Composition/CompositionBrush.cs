
using System;

namespace Windows.UI.Composition
{
	public partial class CompositionBrush : CompositionObject
	{
		internal CompositionBrush() => throw new NotSupportedException();

		public CompositionBrush(Compositor compositor) : base(compositor)
		{

		}
	}
}
