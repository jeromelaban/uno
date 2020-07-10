using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using System;
using View = Windows.UI.Xaml.UIElement;

namespace Windows.UI.Xaml.Controls
{
	public partial class UIElementCollection : BatchCollection<UIElement>
	{

		internal UIElementCollection(FrameworkElement view) : base(view)
		{
		}

		protected override void AddCore(View item) => throw new NotSupportedException();

		protected override IEnumerable<View> ClearCore() => throw new NotSupportedException();

		protected override bool ContainsCore(View item) => throw new NotSupportedException();

		protected override void CopyToCore(View[] array, int arrayIndex) => throw new NotSupportedException();

		protected override int CountCore() => throw new NotSupportedException();

		protected override View GetAtIndexCore(int index) => throw new NotSupportedException();

		protected override List<View>.Enumerator GetEnumeratorCore() => throw new NotSupportedException();

		protected override int IndexOfCore(View item) => throw new NotSupportedException();

		protected override void InsertCore(int index, View item) => throw new NotSupportedException();

		protected override void MoveCore(uint oldIndex, uint newIndex) => throw new NotSupportedException();

		protected override View RemoveAtCore(int index) => throw new NotSupportedException();

		protected override bool RemoveCore(View item) => throw new NotSupportedException();

		protected override View SetAtIndexCore(int index, View value) => throw new NotSupportedException();
	}
}
