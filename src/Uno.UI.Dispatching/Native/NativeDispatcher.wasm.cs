#nullable enable

using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading;
using System.Threading.Tasks;
using Uno.Foundation.Logging;
using Uno.UI.Dispatching.Native;

namespace Uno.UI.Dispatching
{
	internal sealed partial class NativeDispatcher
	{
#if NET9_0_OR_GREATER
		EventLoop? _eventLoop;
#endif

#pragma warning disable IDE0051 // Remove unused private members
		[JSExport]
		private static void DispatcherCallback()
#pragma warning restore IDE0051 // Remove unused private members
		{
			if (typeof(NativeDispatcher).Log().IsEnabled(LogLevel.Trace))
			{
				typeof(NativeDispatcher).Log().Trace($"[tid:{Environment.CurrentManagedThreadId}]: NativeDispatcher.DispatcherCallback()");
			}

			DispatchItems();
		}

		partial void Initialize()
		{
			IsThreadingSupported = Environment.GetEnvironmentVariable("UNO_BOOTSTRAP_MONO_RUNTIME_FEATURES")
				?.Split(',').Contains("threads", StringComparer.OrdinalIgnoreCase) ?? false;

			if (typeof(NativeDispatcher).Log().IsEnabled(LogLevel.Trace))
			{
				typeof(NativeDispatcher).Log().Trace($"[tid:{Environment.CurrentManagedThreadId}]: NativeDispatcher.Initialize() IsThreadingSupported:{IsThreadingSupported}");
			}

			if (IsThreadingSupported)
			{
				_eventLoop = new();
			}
		}

		internal static bool IsThreadingSupported { get; private set; }

		private bool GetHasThreadAccess()
			=> !IsThreadingSupported || _eventLoop?.ThreadId == Environment.CurrentManagedThreadId;

		/// <summary>
		/// Provide an action that will delegate the dispatch of CoreDispatcher work
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal static Action<Action, NativeDispatcherPriority>? DispatchOverride;

		partial void EnqueueNative(NativeDispatcherPriority priority)
		{
			if (typeof(NativeDispatcher).Log().IsEnabled(LogLevel.Trace))
			{
				typeof(NativeDispatcher).Log().Trace($"[tid:{Environment.CurrentManagedThreadId}]: NativeDispatcher.EnqueueNative()");
			}

			if (DispatchOverride == null)
			{
				if (!IsThreadingSupported)
				{
					_ = NativeMethods.WakeUpAsync();
				}
				else
				{
#if NET9_0_OR_GREATER
					if (typeof(NativeDispatcher).Log().IsEnabled(LogLevel.Trace))
					{
						typeof(NativeDispatcher).Log().Trace($"[tid:{Environment.CurrentManagedThreadId}]: _eventLoop?.Schedule {_eventLoop}");
					}

					_eventLoop?.Schedule(() =>
					{
						if (typeof(NativeDispatcher).Log().IsEnabled(LogLevel.Trace))
						{
							typeof(NativeDispatcher).Log().Trace($"[tid:{Environment.CurrentManagedThreadId}]: inside _eventLoop?.Schedule {_eventLoop}");
						}

						NativeDispatcher.DispatchItems();
					});

#else
					// This is a separate function to avoid enclosing early resolution
					// by the interpreter/JIT, in case we're running the non-threaded
					// runtime.
					static void InvokeOnMainThread()
						=> WebAssembly.JSInterop.InternalCalls.InvokeOnMainThread();

					InvokeOnMainThread();
#endif
				}
			}
			else
			{
				Console.WriteLine($"DispatchOverride");
				DispatchOverride(NativeDispatcher.DispatchItems, priority);
			}
		}

		internal static partial class NativeMethods
		{
			[JSImport("globalThis.Uno.UI.Dispatching.NativeDispatcher.WakeUpAsync")]
			internal static partial Task WakeUpAsync();
		}
	}
}
