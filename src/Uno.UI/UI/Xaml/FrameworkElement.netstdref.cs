using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using View = Windows.UI.Xaml.UIElement;
using System.Collections;
using Uno.UI;

namespace Windows.UI.Xaml
{
	public partial class FrameworkElement : IEnumerable
	{
		bool IFrameworkElementInternal.HasLayouter => true;

		internal List<View> _children = new List<View>();

		partial void OnLoadingPartial();

		public T AddChild<T>(T child) where T : View
		{
			_children.Add(child);
			OnAddChild(child);

			return child;
		}

		public T AddChild<T>(T child, int index) where T : View
		{
			_children.Insert(index, child);
			OnAddChild(child);

			return child;
		}

		private void OnAddChild(View child)
		{
		}
		
		public T RemoveChild<T>(T child) where T : View
		{
			return child;
		}

		public View FindFirstChild()
		{
			return _children.FirstOrDefault();
		}

		public virtual IEnumerable<View> GetChildren()
		{
			return _children;
		}

		public bool HasParent()
		{
			return Parent != null;
		}

		partial void OnMeasurePartial(Size slotSize)
		{
			
		}

		internal void InternalArrange(Rect frame)
		{
		}

		partial void OnGenericPropertyUpdatedPartial(DependencyPropertyChangedEventArgs args);

		public bool IsLoaded { get; private set; }

		public void ForceLoaded()
		{
			IsLoaded = true;
			EnterTree();
		}

		private void EnterTree()
		{
		}

		public int InvalidateMeasureCallCount { get; private set; }

		private bool IsTopLevelXamlView() => false;

		internal void SuspendRendering() => throw new NotSupportedException();

		internal void ResumeRendering() => throw new NotSupportedException();
		public IEnumerator GetEnumerator() => _children.GetEnumerator();

		public double ActualWidth => 0;

		public double ActualHeight => 0;

		public Size UnclippedDesiredSize => new Size();

		public global::System.Uri BaseUri { get; internal set; }

		private protected virtual double GetActualWidth() => ActualWidth;
		private protected virtual double GetActualHeight() => ActualHeight;
	}
}
