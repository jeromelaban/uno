#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Dispatching
{
	#if __ANDROID__ || __IOS__ || false || __WASM__ || __SKIA__ || false || false
	public delegate void DispatcherQueueHandler();
	#endif
}
