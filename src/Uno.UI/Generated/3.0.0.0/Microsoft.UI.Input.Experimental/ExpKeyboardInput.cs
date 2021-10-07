#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Microsoft.UI.Input.Experimental
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ExpKeyboardInput : global::Microsoft.UI.Input.Experimental.ExpInputObject
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  string CurrentKeyEventDeviceId
		{
			get
			{
				throw new global::System.NotImplementedException("The member string ExpKeyboardInput.CurrentKeyEventDeviceId is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.CurrentKeyEventDeviceId.get
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Core.CoreVirtualKeyStates GetCurrentKeyState( global::Windows.System.VirtualKey virtualKey)
		{
			throw new global::System.NotImplementedException("The member CoreVirtualKeyStates ExpKeyboardInput.GetCurrentKeyState(VirtualKey virtualKey) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  global::Windows.UI.Core.CoreVirtualKeyStates GetKeyState( global::Windows.System.VirtualKey virtualKey)
		{
			throw new global::System.NotImplementedException("The member CoreVirtualKeyStates ExpKeyboardInput.GetKeyState(VirtualKey virtualKey) is not implemented in Uno.");
		}
		#endif
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.AcceleratorKeyActivated.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.AcceleratorKeyActivated.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.CharacterReceived.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.CharacterReceived.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.KeyDown.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.KeyDown.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.KeyUp.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.KeyUp.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.SysKeyDown.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.SysKeyDown.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.SysKeyUp.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.SysKeyUp.remove
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.ContextMenuKey.add
		// Forced skipping of method Microsoft.UI.Input.Experimental.ExpKeyboardInput.ContextMenuKey.remove
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public static global::Microsoft.UI.Input.Experimental.ExpKeyboardInput GetForInputSite( global::Microsoft.UI.Input.Experimental.ExpInputSite inputSite)
		{
			throw new global::System.NotImplementedException("The member ExpKeyboardInput ExpKeyboardInput.GetForInputSite(ExpInputSite inputSite) is not implemented in Uno.");
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.AcceleratorKeyEventArgs> AcceleratorKeyActivated
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, AcceleratorKeyEventArgs> ExpKeyboardInput.AcceleratorKeyActivated");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, AcceleratorKeyEventArgs> ExpKeyboardInput.AcceleratorKeyActivated");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.CharacterReceivedEventArgs> CharacterReceived
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, CharacterReceivedEventArgs> ExpKeyboardInput.CharacterReceived");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, CharacterReceivedEventArgs> ExpKeyboardInput.CharacterReceived");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Microsoft.UI.Input.Experimental.ExpContextMenuKeyEventArgs> ContextMenuKey
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, ExpContextMenuKeyEventArgs> ExpKeyboardInput.ContextMenuKey");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, ExpContextMenuKeyEventArgs> ExpKeyboardInput.ContextMenuKey");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.KeyEventArgs> KeyDown
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.KeyDown");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.KeyDown");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.KeyEventArgs> KeyUp
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.KeyUp");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.KeyUp");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.KeyEventArgs> SysKeyDown
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.SysKeyDown");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.SysKeyDown");
			}
		}
		#endif
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __SKIA__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
		public  event global::Windows.Foundation.TypedEventHandler<global::Microsoft.UI.Input.Experimental.ExpKeyboardInput, global::Windows.UI.Core.KeyEventArgs> SysKeyUp
		{
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			add
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.SysKeyUp");
			}
			[global::Uno.NotImplemented("__ANDROID__", "__IOS__", "NET461", "__WASM__", "__SKIA__", "__NETSTD_REFERENCE__", "__MACOS__")]
			remove
			{
				global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Microsoft.UI.Input.Experimental.ExpKeyboardInput", "event TypedEventHandler<ExpKeyboardInput, KeyEventArgs> ExpKeyboardInput.SysKeyUp");
			}
		}
		#endif
	}
}
