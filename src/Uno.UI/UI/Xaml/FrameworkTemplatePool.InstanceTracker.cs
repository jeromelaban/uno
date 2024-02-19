﻿#nullable enable

using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Uno.UI.DataBinding;

#if __ANDROID__
using View = Android.Views.View;
#elif __IOS__
using View = UIKit.UIView;
#elif __MACOS__
using View = AppKit.NSView;
#else
using View = Microsoft.UI.Xaml.UIElement;
#endif

namespace Microsoft.UI.Xaml
{
	public partial class FrameworkTemplatePool
	{
		/// <summary>
		/// Provides a backdoor into active tracked instances for testing purposes.
		/// </summary>
		internal static int ActiveInstanceTrackers => InstanceTracker.ActiveInstanceTrackers;

		/// <summary>
		/// The InstanceTracker allows children to be returned to the <see cref="FrameworkTemplatePool"/>.
		/// It does so by tying the lifetime of the parent to their children using <see cref="DependentHandle"/>
		/// and <see cref="TrackerCookie">TrackerCookie</see> without creating strong references.
		/// Once a parent is collected, the cookie becomes eligible for gc, its finalizer will run,
		/// the child will set its parent to null and make itself available to the template pool to be reused.
		/// </summary>
		private static class InstanceTracker
		{
			/// <summary>
			/// Tracks the list of parent-tracked views. This ensures that while a view produced by the <see cref="FrameworkTemplatePool"/>,
			/// it cannot be collected by the GC.
			/// </summary>
			private static readonly Dictionary<View, DependentHandle> _activeInstances = new();

			/// <summary>
			/// A recycling pool of cookies, used to reduce allocations.
			/// </summary>
			private static readonly Stack<TrackerCookie> _cookiePool = new();

			private const int MaxCookiePoolSize = 256;

			/// <summary>
			/// Number of active tracked instances
			/// </summary>
			internal static int ActiveInstanceTrackers => _activeInstances.Count;

			/// <summary>
			/// Adds a view for upcoming parent tracking
			/// </summary>
			public static void Add(View instance)
				=> _activeInstances.Add(instance, default);

			/// <summary>
			/// Cancels the parent tracking for a view
			/// </summary>
			/// <param name="instance">The view instance</param>
			/// <param name="parent"></param>
			public static void TryCancelTracking(View instance, object? parent)
			{
				// Console.WriteLine($"Cancel tracking for {instance.GetType()}/{instance.GetHashCode():X8}, Parent {parent?.GetType()}/{parent?.GetHashCode():X8}");

				ref var handle = ref CollectionsMarshal.GetValueRefOrNullRef(_activeInstances, instance);

				if (!Unsafe.IsNullRef(ref handle) && handle.IsAllocated)
				{
					CancelRecycling(ref handle);

					_activeInstances.Remove(instance);

					GC.KeepAlive(parent);
				}
			}

			private static void CancelRecycling(ref DependentHandle handle, bool returnCookie = true)
			{
				var (target, dependent) = handle.TargetAndDependent;

				if (target != null && returnCookie)
				{
					var cookie = Unsafe.As<TrackerCookie>(dependent)!;

					TryReturnCookie(cookie);
				}

				handle.Dispose();

				GC.KeepAlive(target);
			}

			/// <summary>
			/// Registers the tracking of the specified parent for a view instance, in order for the
			/// instance to be recycled when the parent is garbage collected.
			/// </summary>
			public static void TryRegisterForTracking(FrameworkTemplate template, View instance, object parent, object? oldParent)
			{
				ref var handle = ref CollectionsMarshal.GetValueRefOrNullRef(_activeInstances, instance);

				if (!Unsafe.IsNullRef(ref handle))
				{
					TrackerCookie? cookie = null;

					if (handle.IsAllocated)
					{
						var (target, dependent) = handle.TargetAndDependent;

						if (target != null)
						{
							cookie = Unsafe.As<TrackerCookie>(dependent)!;
						}

						handle.Dispose();

						GC.KeepAlive(oldParent);
					}

					if (cookie == null)
					{
						lock (_cookiePool)
						{
							if (_cookiePool.TryPop(out cookie))
							{
								cookie.SetTargetInstance(instance, parent.GetType(), parent.GetHashCode());
								cookie.SetTargetTemplate(template);
							}
							else
							{
								cookie = new TrackerCookie(instance, template, parent.GetType(), parent.GetHashCode());
							}
						}
					}

					handle = new DependentHandle(parent, cookie);
				}

				//Console.WriteLine($"Registered tracking for {instance.GetType()}/{instance.GetHashCode():X8}, Parent {parent.GetType()}/{parent.GetHashCode():X8}");
			}

			/// <summary>
			/// Explicitly remove the specified instance from the parent tracking. This method is meant to 
			/// be called through an explicit release of a template instance, (e.g. when Control.Template changes).
			/// </summary>
			public static bool TryRemove(View instance, bool returnCookie = true)
			{
				//Console.WriteLine($"Remove tracking for {instance.GetType()}/{instance.GetHashCode():X8}");

				ref var handle = ref CollectionsMarshal.GetValueRefOrNullRef(_activeInstances, instance);

				if (!Unsafe.IsNullRef(ref handle))
				{
					if (handle.IsAllocated)
					{
						CancelRecycling(ref handle, returnCookie);
					}

					_activeInstances.Remove(instance);

					return true;
				}
				else
				{
					//Console.WriteLine($"Unable to find instance {instance.GetType()}/{instance.GetHashCode():X8}");
				}

				return false;
			}

			private static void TryReturnCookie(TrackerCookie cookie, bool finalizing = false)
			{
				lock (_cookiePool)
				{
					if (_cookiePool.Count < MaxCookiePoolSize)
					{
						cookie.SetTargetInstance(null, null, null);
						cookie.SetTargetTemplate(null);

						if (finalizing)
						{
							GC.ReRegisterForFinalize(cookie);
						}

						_cookiePool.Push(cookie);
					}
					else if (!finalizing)
					{
						GC.SuppressFinalize(cookie);
					}
				}
			}

			public class TrackerCookie
			{
				private ManagedWeakReference? _instance;
				private FrameworkTemplate? _template;
				private Type? _parentType;
				private int? _parentHashCode;

				public TrackerCookie(View instance, FrameworkTemplate template, Type parentType, int parentHashCode)
				{
					_instance = WeakReferencePool.RentWeakReference(null, instance);
					_template = template;
					_parentType = parentType;
					_parentHashCode = parentHashCode;
				}

				~TrackerCookie()
				{
					//Console.WriteLine($"TrackerCookie for parent {_parentType}/{_parentHashCode:X8} for instance {_instance?.Target?.GetType()}/{_instance?.Target?.GetHashCode():X8}");

					if (_template is not null && _instance?.Target is View view)
					{
						Instance.RaiseOnParentCollected(_template, view);
					}
					else
					{

					}

					// If the pool wasn't full, resurrect the cookie so its finalizer will run again
					TryReturnCookie(this, finalizing: true);
				}

				public void SetTargetInstance(View? view, Type? parentType, int? parentHashCode)
				{
					_instance = view is not null
							? WeakReferencePool.RentWeakReference(null, view)
							: null;

					_parentType = parentType;
					_parentHashCode = parentHashCode;
				}

				public void SetTargetTemplate(FrameworkTemplate? template)
				{
					_template = template;
				}
			}
		}
	}
}
