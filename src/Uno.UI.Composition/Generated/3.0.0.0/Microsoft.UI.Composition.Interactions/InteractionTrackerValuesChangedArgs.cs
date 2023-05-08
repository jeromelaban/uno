#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition.Interactions
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class InteractionTrackerValuesChangedArgs 
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::System.Numerics.Vector3 Position
		{
			get
			{
				throw new global::System.NotImplementedException("The member Vector3 InteractionTrackerValuesChangedArgs.Position is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=Vector3%20InteractionTrackerValuesChangedArgs.Position");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  int RequestId
		{
			get
			{
				throw new global::System.NotImplementedException("The member int InteractionTrackerValuesChangedArgs.RequestId is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20InteractionTrackerValuesChangedArgs.RequestId");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  float Scale
		{
			get
			{
				throw new global::System.NotImplementedException("The member float InteractionTrackerValuesChangedArgs.Scale is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=float%20InteractionTrackerValuesChangedArgs.Scale");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.Interactions.InteractionTrackerValuesChangedArgs.RequestId.get
		// Forced skipping of method Microsoft.UI.Composition.Interactions.InteractionTrackerValuesChangedArgs.Position.get
		// Forced skipping of method Microsoft.UI.Composition.Interactions.InteractionTrackerValuesChangedArgs.Scale.get
	}
}
