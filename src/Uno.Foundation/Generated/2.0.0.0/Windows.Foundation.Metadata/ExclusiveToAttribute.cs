#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Foundation.Metadata
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExclusiveToAttribute : global::System.Attribute
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented]
		public ExclusiveToAttribute( global::System.Type typeName) : base()
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Foundation.Metadata.ExclusiveToAttribute", "ExclusiveToAttribute.ExclusiveToAttribute(Type typeName)");
		}
		#endif
		// Forced skipping of method Windows.Foundation.Metadata.ExclusiveToAttribute.ExclusiveToAttribute(System.Type)
	}
}
