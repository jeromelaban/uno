using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Uno.Extensions;
using System;

namespace Windows.UI.Xaml.Controls
{
	public partial class UIElementCollection : BatchCollection<UIElement>
	{
		private readonly UIElement _view;

		internal UIElementCollection(UIElement view) : base(view)
		{
			_view = view;
		}

		protected override void AddCore(UIElement item)
		{
			_view.AddChild(item);
		}

		protected override IEnumerable<UIElement> ClearCore()
		{
			var deleted = _view._children.ToArray();
			_view.ClearChildren();

			return deleted;
		}

		protected override bool ContainsCore(UIElement item)
		{
			return _view._children.Contains(item);
		}

		protected override void CopyToCore(UIElement[] array, int arrayIndex)
			=> _view._children.ToArray().CopyTo(array, arrayIndex);


		protected override int CountCore() => _view._children.Count;

		protected override UIElement GetAtIndexCore(int index) => _view._children[index];

		protected override List<UIElement>.Enumerator GetEnumeratorCore() => _view._children.GetEnumerator();

		protected override int IndexOfCore(UIElement item) => _view._children.IndexOf(item);

		protected override void InsertCore(int index, UIElement item)
		{
			_view.AddChild(item, index);
		}

		protected override void MoveCore(uint oldIndex, uint newIndex)
		{
			// _view.MoveChildTo((int)oldIndex, (int)newIndex);
		}

		protected override UIElement RemoveAtCore(int index)
		{
			var item = _view._children.ElementAtOrDefault(index);
			_view.RemoveChild(item);
			return item;
		}

		protected override bool RemoveCore(UIElement item) => _view.RemoveChild(item) != null;

		protected override UIElement SetAtIndexCore(int index, UIElement value) => throw new NotImplementedException();
	}
}
