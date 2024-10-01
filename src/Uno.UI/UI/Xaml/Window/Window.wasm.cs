using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using Uno;
using Uno.UI.Xaml.Controls;

namespace Microsoft.UI.Xaml;

partial class Window
{
	[JSExport]
	[Preserve]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	internal static async Task ResizeAsync(double width, double height)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
		=> NativeWindowWrapper.Instance.RaiseNativeSizeChanged(width, height);
}
