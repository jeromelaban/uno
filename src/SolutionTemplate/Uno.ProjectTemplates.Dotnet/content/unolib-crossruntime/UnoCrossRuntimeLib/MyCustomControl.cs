using System;
using Microsoft/* UWP don't rename */.UI.Xaml.Controls;

namespace UnoCrossRuntimeLib
{
	public partial class MyCustomControl : UserControl
	{
		public MyCustomControl()
		{
#if __WASM__
			Content = new TextBlock
			{
				Text = Uno.Foundation.WebAssemblyRuntime.InvokeJS("navigator.userAgent;")
			};
#endif
		}
	}
}
