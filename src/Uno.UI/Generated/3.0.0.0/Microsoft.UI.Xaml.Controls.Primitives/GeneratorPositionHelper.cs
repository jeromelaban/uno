#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Controls.Primitives
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class GeneratorPositionHelper 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.Controls.Primitives.GeneratorPosition FromIndexAndOffset( int index,  int offset)
		{
			throw new global::System.NotImplementedException("The member GeneratorPosition GeneratorPositionHelper.FromIndexAndOffset(int index, int offset) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=GeneratorPosition%20GeneratorPositionHelper.FromIndexAndOffset%28int%20index%2C%20int%20offset%29");
		}
		#endif
	}
}
