// MUX reference PagerControlSelectedIndexChangedEventArgs.cpp, commit a08f765

namespace Microsoft/* UWP don't rename */.UI.Xaml.Controls
{
	public partial class PagerControlSelectedIndexChangedEventArgs
	{
		public PagerControlSelectedIndexChangedEventArgs(int previousIndex, int newIndex)
		{
			PreviousPageIndex = previousIndex;
			NewPageIndex = newIndex;
		}

		public int PreviousPageIndex { get; }

		public int NewPageIndex { get; }
	}
}
