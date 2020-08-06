// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Foundation;
using Microsoft.Extensions.DependencyInjection;
using ObjCRuntime;

namespace Microsoft.Extensions.Logging.NSLogger
{
	/// <summary>
	/// A logger that writes messages in the debug output window only when a debugger is attached.
	/// </summary>
	public partial class NSDebugLogger : ILogger
	{
		private readonly Func<string, LogLevel, bool> _filter;
		private readonly string _name;

		[DllImport(Constants.FoundationLibrary)]
		extern static void NSLog(IntPtr format, IntPtr s);

		static NSString format = new NSString("%@");

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugLogger"/> class.
		/// </summary>
		/// <param name="name">The name of the logger.</param>
		public NSDebugLogger(string name) : this(name, filter: null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugLogger"/> class.
		/// </summary>
		/// <param name="name">The name of the logger.</param>
		/// <param name="filter">The function used to filter events based on the log level.</param>
		public NSDebugLogger(string name, Func<string, LogLevel, bool> filter)
		{
			_name = string.IsNullOrEmpty(name) ? nameof(NSDebugLogger) : name;
			_filter = filter;
		}


		/// <inheritdoc />
		public IDisposable BeginScope<TState>(TState state)
		{
			return NoopDisposable.Instance;
		}

		/// <inheritdoc />
		public bool IsEnabled(LogLevel logLevel)
		{
			// If the filter is null, everything is enabled
			// unless the debugger is not attached
			return Debugger.IsAttached &&
				logLevel != LogLevel.None &&
				(_filter == null || _filter(_name, logLevel));
		}

		/// <inheritdoc />
		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			if (!IsEnabled(logLevel))
			{
				return;
			}

			if (formatter == null)
			{
				throw new ArgumentNullException(nameof(formatter));
			}

			var message = formatter(state, exception);

			if (string.IsNullOrEmpty(message))
			{
				return;
			}

			message = $"{ logLevel }: {message}";

			if (exception != null)
			{
				message += Environment.NewLine + Environment.NewLine + exception.ToString();
			}

			using (var ns = new NSString(message))
			{
				NSLog(format.Handle, ns.Handle);
			}
		}

		private class NoopDisposable : IDisposable
		{
			public static NoopDisposable Instance = new NoopDisposable();

			public void Dispose()
			{
			}
		}
	}

	/// <summary>
	/// The provider for the <see cref="DebugLogger"/>.
	/// </summary>
	public class NSLoggerProvider : ILoggerProvider
	{
		private readonly Func<string, LogLevel, bool> _filter;

		public NSLoggerProvider()
		{
			_filter = null;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DebugLoggerProvider"/> class.
		/// </summary>
		/// <param name="filter">The function used to filter events based on the log level.</param>
		public NSLoggerProvider(Func<string, LogLevel, bool> filter)
		{
			_filter = filter;
		}

		/// <inheritdoc />
		public ILogger CreateLogger(string name)
		{
			return new NSDebugLogger(name, _filter);
		}

		public void Dispose()
		{
		}
	}

	/// <summary>
	/// Extension methods for the <see cref="ILoggerFactory"/> class.
	/// </summary>
	public static class NSDebugLoggerFactoryExtensions
	{
		/// <summary>
		/// Adds a debug logger that is enabled for <see cref="LogLevel"/>.Information or higher.
		/// </summary>
		/// <param name="factory">The extension method argument.</param>
		public static ILoggerFactory AddNSLog(this ILoggerFactory factory)
		{
			return AddNSLog(factory, LogLevel.Information);
		}

		/// <summary>
		/// Adds a debug logger that is enabled as defined by the filter function.
		/// </summary>
		/// <param name="factory">The extension method argument.</param>
		/// <param name="filter">The function used to filter events based on the log level.</param>
		public static ILoggerFactory AddNSLog(this ILoggerFactory factory, Func<string, LogLevel, bool> filter)
		{
			factory.AddProvider(new NSLoggerProvider(filter));
			return factory;
		}

		/// <summary>
		/// Adds a debug logger that is enabled for <see cref="LogLevel"/>s of minLevel or higher.
		/// </summary>
		/// <param name="factory">The extension method argument.</param>
		/// <param name="minLevel">The minimum <see cref="LogLevel"/> to be logged</param>
		public static ILoggerFactory AddNSLog(this ILoggerFactory factory, LogLevel minLevel)
		{
			return AddNSLog(
			   factory,
			   (_, logLevel) => logLevel >= minLevel);
		}
	}
}
