#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class PointerPredictor : global::System.IDisposable
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.TimeSpan PredictionTime
		{
			get
			{
				throw new global::System.NotImplementedException("The member TimeSpan PointerPredictor.PredictionTime is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=TimeSpan%20PointerPredictor.PredictionTime");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.PointerPredictor", "TimeSpan PointerPredictor.PredictionTime");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.PointerPredictor.PredictionTime.get
		// Forced skipping of method Microsoft.UI.Input.PointerPredictor.PredictionTime.set
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Microsoft.UI.Input.PointerPoint[] GetPredictedPoints( global::Microsoft.UI.Input.PointerPoint point)
		{
			throw new global::System.NotImplementedException("The member PointerPoint[] PointerPredictor.GetPredictedPoints(PointerPoint point) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=PointerPoint%5B%5D%20PointerPredictor.GetPredictedPoints%28PointerPoint%20point%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  void Dispose()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.PointerPredictor", "void PointerPredictor.Dispose()");
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.PointerPredictor CreateForInputPointerSource( global::Microsoft.UI.Input.InputPointerSource inputPointerSource)
		{
			throw new global::System.NotImplementedException("The member PointerPredictor PointerPredictor.CreateForInputPointerSource(InputPointerSource inputPointerSource) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=PointerPredictor%20PointerPredictor.CreateForInputPointerSource%28InputPointerSource%20inputPointerSource%29");
		}
		#endif
		// Processing: System.IDisposable
	}
}
