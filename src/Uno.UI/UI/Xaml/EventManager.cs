#nullable enable
using System;
using System.Collections.Generic;
using System.Text;
using Windows.Networking.Sockets;
using Windows.UI.Core;

namespace Windows.UI.Xaml
{
	internal class EventManager
	{
		[ThreadStatic]
		private static EventManager? _manager;

		private List<Action> _actions = new List<Action>();
		private bool _nextTickIsQueued = false;

		public static EventManager GetForCurrentThread()
			=> _manager ??= new EventManager();

		internal void QueueOperation(Action action)
		{
			_actions.Add(action);

			if (!_nextTickIsQueued)
			{
				CoreWindow.GetForCurrentThread().Dispatcher.RunOnNextTick(ProcessEvents);
				_nextTickIsQueued = true;
			}
		}

		private void ProcessEvents()
		{
			var currentActions = _actions;
			_actions = new List<Action>();

			_nextTickIsQueued = false;
			foreach(var action in currentActions)
			{
				action();
			}
		}
	}
}
