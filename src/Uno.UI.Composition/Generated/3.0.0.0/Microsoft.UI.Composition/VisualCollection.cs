#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Composition
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
	#endif
	public  partial class VisualCollection : global::Microsoft.UI.Composition.CompositionObject,global::System.Collections.Generic.IEnumerable<global::Microsoft.UI.Composition.Visual>
	{
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  int Count
		{
			get
			{
				throw new global::System.NotImplementedException("The member int VisualCollection.Count is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=int%20VisualCollection.Count");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void InsertAtBottom( global::Microsoft.UI.Composition.Visual newChild)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.InsertAtBottom(Visual newChild)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void InsertAbove( global::Microsoft.UI.Composition.Visual newChild,  global::Microsoft.UI.Composition.Visual sibling)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.InsertAbove(Visual newChild, Visual sibling)");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.VisualCollection.Count.get
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void InsertAtTop( global::Microsoft.UI.Composition.Visual newChild)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.InsertAtTop(Visual newChild)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void InsertBelow( global::Microsoft.UI.Composition.Visual newChild,  global::Microsoft.UI.Composition.Visual sibling)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.InsertBelow(Visual newChild, Visual sibling)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void Remove( global::Microsoft.UI.Composition.Visual child)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.Remove(Visual child)");
		}
		#endif
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public  void RemoveAll()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Composition.VisualCollection", "void VisualCollection.RemoveAll()");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Composition.VisualCollection.First()
		// Processing: System.Collections.Generic.IEnumerable<Microsoft.UI.Composition.Visual>
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		// DeclaringType: System.Collections.Generic.IEnumerable<Microsoft.UI.Composition.Visual>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		public global::System.Collections.Generic.IEnumerator<global::Microsoft.UI.Composition.Visual> GetEnumerator()
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		// Processing: System.Collections.IEnumerable
		#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
		// DeclaringType: System.Collections.IEnumerable
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "__WASM__", "__SKIA__")]
		 global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			throw new global::System.NotSupportedException();
		}
		#endif
	}
}
