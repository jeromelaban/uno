#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Composition
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class CompositionProjectedShadowReceiver : global::Windows.UI.Composition.CompositionObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::Windows.UI.Composition.Visual ReceivingVisual
		{
			get
			{
				throw new global::System.NotImplementedException("The member Visual CompositionProjectedShadowReceiver.ReceivingVisual is not implemented in Uno.");
			}
			set
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Composition.CompositionProjectedShadowReceiver", "Visual CompositionProjectedShadowReceiver.ReceivingVisual");
			}
		}
		#endif
		// Forced skipping of method Windows.UI.Composition.CompositionProjectedShadowReceiver.ReceivingVisual.get
		// Forced skipping of method Windows.UI.Composition.CompositionProjectedShadowReceiver.ReceivingVisual.set
	}
}
