#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Xaml.Media
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class MatrixHelper 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.Media.Matrix Identity
		{
			get
			{
				throw new global::System.NotImplementedException("The member Matrix MatrixHelper.Identity is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Matrix%20MatrixHelper.Identity");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Xaml.Media.MatrixHelper.Identity.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Xaml.Media.Matrix FromElements( double m11,  double m12,  double m21,  double m22,  double offsetX,  double offsetY)
		{
			throw new global::System.NotImplementedException("The member Matrix MatrixHelper.FromElements(double m11, double m12, double m21, double m22, double offsetX, double offsetY) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Matrix%20MatrixHelper.FromElements%28double%20m11%2C%20double%20m12%2C%20double%20m21%2C%20double%20m22%2C%20double%20offsetX%2C%20double%20offsetY%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static bool GetIsIdentity( global::Microsoft.UI.Xaml.Media.Matrix target)
		{
			throw new global::System.NotImplementedException("The member bool MatrixHelper.GetIsIdentity(Matrix target) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20MatrixHelper.GetIsIdentity%28Matrix%20target%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Windows.Foundation.Point Transform( global::Microsoft.UI.Xaml.Media.Matrix target,  global::Windows.Foundation.Point point)
		{
			throw new global::System.NotImplementedException("The member Point MatrixHelper.Transform(Matrix target, Point point) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Point%20MatrixHelper.Transform%28Matrix%20target%2C%20Point%20point%29");
		}
		#endif
	}
}
