#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Storage
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class StorageLibraryChange 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Storage.StorageLibraryChangeType ChangeType
		{
			get
			{
				throw new global::System.NotImplementedException("The member StorageLibraryChangeType StorageLibraryChange.ChangeType is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=StorageLibraryChangeType%20StorageLibraryChange.ChangeType");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string Path
		{
			get
			{
				throw new global::System.NotImplementedException("The member string StorageLibraryChange.Path is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20StorageLibraryChange.Path");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string PreviousPath
		{
			get
			{
				throw new global::System.NotImplementedException("The member string StorageLibraryChange.PreviousPath is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=string%20StorageLibraryChange.PreviousPath");
			}
		}
		#endif
		// Forced skipping of method Windows.Storage.StorageLibraryChange.ChangeType.get
		// Forced skipping of method Windows.Storage.StorageLibraryChange.Path.get
		// Forced skipping of method Windows.Storage.StorageLibraryChange.PreviousPath.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  bool IsOfType( global::Windows.Storage.StorageItemTypes type)
		{
			throw new global::System.NotImplementedException("The member bool StorageLibraryChange.IsOfType(StorageItemTypes type) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=bool%20StorageLibraryChange.IsOfType%28StorageItemTypes%20type%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.Foundation.IAsyncOperation<global::Windows.Storage.IStorageItem> GetStorageItemAsync()
		{
			throw new global::System.NotImplementedException("The member IAsyncOperation<IStorageItem> StorageLibraryChange.GetStorageItemAsync() is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=IAsyncOperation%3CIStorageItem%3E%20StorageLibraryChange.GetStorageItemAsync%28%29");
		}
		#endif
	}
}
