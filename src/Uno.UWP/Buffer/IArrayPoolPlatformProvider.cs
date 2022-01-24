// Imported from https://github.com/dotnet/corefx/commit/d9d1e815ad6c642cf5d61afa4a16726548598bb2 until Xamarin exposes it properly.
//
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Uno.Buffers
{
	internal interface IArrayPoolPlatformProvider
	{
		bool CanUseMemoryManager { get; }

		Windows.System.AppMemoryUsageLevel AppMemoryUsageLevel { get; }

		TimeSpan Now { get; }

		void RegisterTrimCallback(Func<object, bool> callback, object arrayPool);
	}
}
