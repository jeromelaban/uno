using System;
using System.Diagnostics;
using Windows.System;

namespace Uno.Buffers
{
	internal class DefaultArrayPoolPlatformProvider : IArrayPoolPlatformProvider
	{
		private static readonly bool _canUseMemoryManager;
		private readonly Stopwatch _watch = new();
		private TimeSpan _lastMemorySnapshot = TimeSpan.FromMinutes(-30);
		private ulong _appMemoryUsageLimit;
		private ulong _appMemoryUsage;
		private Windows.System.AppMemoryUsageLevel _appMemoryUsageUsageLevel;
		private readonly static TimeSpan MemoryUsageUpdateResolution = TimeSpan.FromSeconds(5);

		static DefaultArrayPoolPlatformProvider()
		{
			_canUseMemoryManager =
				Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent("Windows.System.MemoryManager", "AppMemoryUsage")
				&& Windows.System.MemoryManager.IsAvailable;
		}

		public DefaultArrayPoolPlatformProvider()
		{
			_watch.Start();
		}

		public TimeSpan Now
			=> _watch.Elapsed;

		public bool CanUseMemoryManager => _canUseMemoryManager;

		public ulong AppMemoryUsage
		{
			get
			{
				UpdateMemoryUsage();
				return _appMemoryUsage;
			}
		}

		public ulong AppMemoryUsageLimit
		{
			get
			{
				UpdateMemoryUsage();
				return _appMemoryUsageLimit;
			}
		}

		public AppMemoryUsageLevel AppMemoryUsageLevel
		{
			get
			{
				UpdateMemoryUsage();
				return _appMemoryUsageUsageLevel;
			}
		}

		private void UpdateMemoryUsage()
		{
			if (Now - _lastMemorySnapshot > MemoryUsageUpdateResolution)
			{
				_lastMemorySnapshot = Now;
				_appMemoryUsageLimit = Windows.System.MemoryManager.AppMemoryUsageLimit;
				_appMemoryUsage = Windows.System.MemoryManager.AppMemoryUsage;
				_appMemoryUsageUsageLevel = Windows.System.MemoryManager.AppMemoryUsageLevel;
			}
		}

		public void RegisterTrimCallback(Func<object, bool> callback, object target)
		{
			Windows.Foundation.Gen2GcCallback.Register(callback, target);
		}
	}
}
