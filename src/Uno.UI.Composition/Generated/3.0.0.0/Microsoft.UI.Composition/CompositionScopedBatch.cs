#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class CompositionScopedBatch : global::Microsoft.UI.Composition.CompositionObject
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  bool IsActive
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool CompositionScopedBatch.IsActive is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20CompositionScopedBatch.IsActive");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  bool IsEnded
		{
			get
			{
				throw new global::System.NotImplementedException("The member bool CompositionScopedBatch.IsEnded is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20CompositionScopedBatch.IsEnded");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionScopedBatch.IsEnded.get
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void End()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionScopedBatch", "void CompositionScopedBatch.End()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionScopedBatch.IsActive.get
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void Suspend()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionScopedBatch", "void CompositionScopedBatch.Suspend()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.CompositionScopedBatch.Completed.add
		// Forced skipping of method Microsoft.UI.Composition.CompositionScopedBatch.Completed.remove
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void Resume()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionScopedBatch", "void CompositionScopedBatch.Resume()");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  event global::Windows.Foundation.TypedEventHandler<object, global::Microsoft.UI.Composition.CompositionBatchCompletedEventArgs> Completed
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionScopedBatch", "event TypedEventHandler<object, CompositionBatchCompletedEventArgs> CompositionScopedBatch.Completed");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.CompositionScopedBatch", "event TypedEventHandler<object, CompositionBatchCompletedEventArgs> CompositionScopedBatch.Completed");
			}
		}
		#endif
	}
}
