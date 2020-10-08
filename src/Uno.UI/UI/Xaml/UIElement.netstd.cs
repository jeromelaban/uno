using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using Windows.Foundation;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Uno.Collections;
using Uno.Extensions;
using Uno.Foundation;
using Uno.Logging;
using Uno.UI;
using Uno.UI.Extensions;
using Uno.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.System;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Uno.Core.Comparison;

namespace Windows.UI.Xaml
{
	public partial class UIElement : DependencyObject
	{
		internal protected readonly ILogger _log;
		private protected readonly ILogger _logDebug;

		private readonly bool _isFrameworkElement;
		internal readonly MaterializableList<UIElement> _children = new MaterializableList<UIElement>();

		// Even if this a concept of FrameworkElement, the loaded state is handled by the UIElement in order to avoid
		// to cast to FrameworkElement each time a child is added or removed.
#if __WASM__
		internal bool IsLoaded { get; private protected set; } // protected for the native loading support
#else
		internal bool IsLoaded { get; private set; }
#endif

		private protected int Depth { get; private set; } = int.MinValue;

		internal static void RootElementEnter(UIElement visualTreeRoot)
			=> visualTreeRoot.Enter();

		internal static void RootElementLeave(UIElement visualTreeRoot)
			=> visualTreeRoot.Leave();

		// Overloads for the FrameworkElement to raise the events
		// (Load/Unload is actually a concept of the FwElement, but it's easier to handle it directly from the UIElement)
		private protected virtual void OnFwEltLoaded() { }
		private protected virtual void OnFwEltUnloaded() { }

		partial void EnterPartial()
		{
			UpdateHitTest();

			EventManager.GetForCurrentThread().QueueOperation(action: () =>
			{
				IsLoaded = true;
				OnFwEltLoaded();
			});

			foreach (var child in _children)
			{
				child.Enter();
			}
		}

		partial void LeavePartial()
		{
			IsLoaded = false;
			Depth = int.MinValue;

			foreach (var child in _children)
			{
				child.Leave();
			}

			OnFwEltUnloaded();
			UpdateHitTest();
		}

		private void OnAddingChild(UIElement child)
		{
			
		}

		private void OnChildAdded(UIElement child)
		{
			if (
#if __WASM__
				!FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded ||
#endif
				!IsActive
				|| !child._isFrameworkElement)
			{
				return;
			}

			if (child.IsActive)
			{
				this.Log().Error($"{this}: Inconsistent state: child {child} is already live (OnChildAdded)");
			}
			else
			{
				child.Enter();
			}
		}

		private void OnChildRemoved(UIElement child)
		{
			if (
#if __WASM__
				!FeatureConfiguration.FrameworkElement.WasmUseManagedLoadedUnloaded ||
#endif
				!IsActive
				|| !child._isFrameworkElement)
			{
				return;
			}

			if (child.IsActive)
			{
				child.Leave();
			}
			else
			{
				this.Log().Error($"{this}: Inconsistent state: child {child} is not live (OnChildRemoved)");
			}
		}

		internal Point GetPosition(Point position, UIElement relativeTo)
			=> TransformToVisual(relativeTo).TransformPoint(position);
	}
}
