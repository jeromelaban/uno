#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Composition
{
	#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class CompositionShapeCollection : global::Windows.UI.Composition.CompositionObject,global::System.Collections.Generic.IList<global::Windows.UI.Composition.CompositionShape>,global::System.Collections.Generic.IEnumerable<global::Windows.UI.Composition.CompositionShape>
	{
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  uint Size
		{
			get
			{
				throw new global::System.NotImplementedException("The member uint CompositionShapeCollection.Size is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=uint%20CompositionShapeCollection.Size");
			}
		}
		#endif
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.GetAt(uint)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.Size.get
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.GetView()
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.IndexOf(Windows.UI.Composition.CompositionShape, out uint)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.SetAt(uint, Windows.UI.Composition.CompositionShape)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.InsertAt(uint, Windows.UI.Composition.CompositionShape)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.RemoveAt(uint)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.Append(Windows.UI.Composition.CompositionShape)
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.RemoveAtEnd()
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.Clear()
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.GetMany(uint, Windows.UI.Composition.CompositionShape[])
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.ReplaceAll(Windows.UI.Composition.CompositionShape[])
		// Forced skipping of method Windows.UI.Composition.CompositionShapeCollection.First()
		// Processing: System.Collections.Generic.IList<Windows.UI.Composition.CompositionShape>
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.IList<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public int IndexOf( global::Windows.UI.Composition.CompositionShape item)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.IList<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public void Insert( int index,  global::Windows.UI.Composition.CompositionShape item)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.IList<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public void RemoveAt( int index)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::Windows.UI.Composition.CompositionShape this[int index]
		{
			get
			{
				throw new global::System.NotSupportedException();
			}
			set
			{
				throw new global::System.NotSupportedException();
			}
		}
		#endif
		// Processing: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public void Add( global::Windows.UI.Composition.CompositionShape item)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public void Clear()
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public bool Contains( global::Windows.UI.Composition.CompositionShape item)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public void CopyTo( global::Windows.UI.Composition.CompositionShape[] array,  int arrayIndex)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.ICollection<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public bool Remove( global::Windows.UI.Composition.CompositionShape item)
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public int Count
		{
			get
			{
				throw new global::System.NotSupportedException();
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public bool IsReadOnly
		{
			get
			{
				throw new global::System.NotSupportedException();
			}
		}
		#endif
		// Processing: System.Collections.Generic.IEnumerable<Windows.UI.Composition.CompositionShape>
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.Generic.IEnumerable<Windows.UI.Composition.CompositionShape>
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public global::System.Collections.Generic.IEnumerator<global::Windows.UI.Composition.CompositionShape> GetEnumerator()
		{
			throw new global::System.NotSupportedException();
		}
		#endif
		// Processing: System.Collections.IEnumerable
		#if __ANDROID__ || __IOS__ || IS_UNIT_TESTS || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		// DeclaringType: System.Collections.IEnumerable
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "IS_UNIT_TESTS", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		 global::System.Collections.IEnumerator global::System.Collections.IEnumerable.GetEnumerator()
		{
			throw new global::System.NotSupportedException();
		}
		#endif
	}
}
