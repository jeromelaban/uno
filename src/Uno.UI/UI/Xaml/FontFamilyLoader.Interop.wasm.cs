using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

namespace __Microsoft.UI.Xaml.Media
{
	internal partial class FontFamilyLoader
	{
		internal static partial class NativeMethods
		{
			[JSImport("globalThis.Microsoft.UI.Xaml.Media.FontFamily.forceFontUsage")]
			internal static partial Task ForceFontUsageAsync(string cssFontName);

			[JSImport("globalThis.Microsoft.UI.Xaml.Media.FontFamily.loadFont")]
			internal static partial Task LoadFontAsync(string cssFontName, string externalSource);
		}
	}
}
