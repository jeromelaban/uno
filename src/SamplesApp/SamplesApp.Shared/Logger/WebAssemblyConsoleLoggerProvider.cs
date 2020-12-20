#if __WASM__
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace SamplesApp.Logger
{
	/// <summary>
	/// A provider of <see cref="WebAssemblyConsoleLogger{T}"/> instances.
	/// </summary>
	internal class WebAssemblyConsoleLoggerProvider : ILoggerProvider
	{
		private readonly ConcurrentDictionary<string, WebAssemblyConsoleLogger<object>> _loggers;

		/// <summary>
		/// Creates an instance of <see cref="WebAssemblyConsoleLoggerProvider"/>.
		/// </summary>
		public WebAssemblyConsoleLoggerProvider()
		{
			_loggers = new ConcurrentDictionary<string, WebAssemblyConsoleLogger<object>>();
		}

		/// <inheritdoc />
		public ILogger CreateLogger(string name)
		{
			return _loggers.GetOrAdd(name, loggerName => new WebAssemblyConsoleLogger<object>(name));
		}

		/// <inheritdoc />
		public void Dispose()
		{
		}
	}
}
#endif
