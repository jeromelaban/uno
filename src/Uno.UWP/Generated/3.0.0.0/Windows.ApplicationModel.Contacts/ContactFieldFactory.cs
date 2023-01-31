#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Contacts
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ContactFieldFactory : global::Windows.ApplicationModel.Contacts.IContactFieldFactory,global::Windows.ApplicationModel.Contacts.IContactLocationFieldFactory,global::Windows.ApplicationModel.Contacts.IContactInstantMessageFieldFactory
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public ContactFieldFactory() 
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.ApplicationModel.Contacts.ContactFieldFactory", "ContactFieldFactory.ContactFieldFactory()");
		}
		#endif
		// Forced skipping of method Windows.ApplicationModel.Contacts.ContactFieldFactory.ContactFieldFactory()
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactField CreateField( string value,  global::Windows.ApplicationModel.Contacts.ContactFieldType type)
		{
			throw new global::System.NotImplementedException("The member ContactField ContactFieldFactory.CreateField(string value, ContactFieldType type) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactField%20ContactFieldFactory.CreateField%28string%20value%2C%20ContactFieldType%20type%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactField CreateField( string value,  global::Windows.ApplicationModel.Contacts.ContactFieldType type,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category)
		{
			throw new global::System.NotImplementedException("The member ContactField ContactFieldFactory.CreateField(string value, ContactFieldType type, ContactFieldCategory category) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactField%20ContactFieldFactory.CreateField%28string%20value%2C%20ContactFieldType%20type%2C%20ContactFieldCategory%20category%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactField CreateField( string name,  string value,  global::Windows.ApplicationModel.Contacts.ContactFieldType type,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category)
		{
			throw new global::System.NotImplementedException("The member ContactField ContactFieldFactory.CreateField(string name, string value, ContactFieldType type, ContactFieldCategory category) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactField%20ContactFieldFactory.CreateField%28string%20name%2C%20string%20value%2C%20ContactFieldType%20type%2C%20ContactFieldCategory%20category%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactLocationField CreateLocation( string unstructuredAddress)
		{
			throw new global::System.NotImplementedException("The member ContactLocationField ContactFieldFactory.CreateLocation(string unstructuredAddress) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactLocationField%20ContactFieldFactory.CreateLocation%28string%20unstructuredAddress%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactLocationField CreateLocation( string unstructuredAddress,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category)
		{
			throw new global::System.NotImplementedException("The member ContactLocationField ContactFieldFactory.CreateLocation(string unstructuredAddress, ContactFieldCategory category) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactLocationField%20ContactFieldFactory.CreateLocation%28string%20unstructuredAddress%2C%20ContactFieldCategory%20category%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactLocationField CreateLocation( string unstructuredAddress,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category,  string street,  string city,  string region,  string country,  string postalCode)
		{
			throw new global::System.NotImplementedException("The member ContactLocationField ContactFieldFactory.CreateLocation(string unstructuredAddress, ContactFieldCategory category, string street, string city, string region, string country, string postalCode) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactLocationField%20ContactFieldFactory.CreateLocation%28string%20unstructuredAddress%2C%20ContactFieldCategory%20category%2C%20string%20street%2C%20string%20city%2C%20string%20region%2C%20string%20country%2C%20string%20postalCode%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactInstantMessageField CreateInstantMessage( string userName)
		{
			throw new global::System.NotImplementedException("The member ContactInstantMessageField ContactFieldFactory.CreateInstantMessage(string userName) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactInstantMessageField%20ContactFieldFactory.CreateInstantMessage%28string%20userName%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactInstantMessageField CreateInstantMessage( string userName,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category)
		{
			throw new global::System.NotImplementedException("The member ContactInstantMessageField ContactFieldFactory.CreateInstantMessage(string userName, ContactFieldCategory category) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactInstantMessageField%20ContactFieldFactory.CreateInstantMessage%28string%20userName%2C%20ContactFieldCategory%20category%29");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.ApplicationModel.Contacts.ContactInstantMessageField CreateInstantMessage( string userName,  global::Windows.ApplicationModel.Contacts.ContactFieldCategory category,  string service,  string displayText,  global::System.Uri verb)
		{
			throw new global::System.NotImplementedException("The member ContactInstantMessageField ContactFieldFactory.CreateInstantMessage(string userName, ContactFieldCategory category, string service, string displayText, Uri verb) is not implemented. For more information, visit https://aka.platform.uno/notimplemented?m=ContactInstantMessageField%20ContactFieldFactory.CreateInstantMessage%28string%20userName%2C%20ContactFieldCategory%20category%2C%20string%20service%2C%20string%20displayText%2C%20Uri%20verb%29");
		}
		#endif
		// Processing: Windows.ApplicationModel.Contacts.IContactFieldFactory
		// Processing: Windows.ApplicationModel.Contacts.IContactLocationFieldFactory
		// Processing: Windows.ApplicationModel.Contacts.IContactInstantMessageFieldFactory
	}
}
