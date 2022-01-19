﻿using System;
using System.Globalization;
using Uno.Foundation;

namespace Windows.System
{
	public partial class MemoryManager
	{
		private const string JsType = "Windows.System.MemoryManager";

		public static ulong AppMemoryUsage
		{
			get
			{
				if(ulong.TryParse(WebAssemblyRuntime.InvokeJS(
					$"{JsType}.getAppMemoryUsage()"),
					NumberStyles.Any,
					CultureInfo.InvariantCulture, out var value))
				{
					return value;
				}

				throw new Exception($"getAppMemoryUsage returned an unsupported value");
			}
		}

		public static ulong AppMemoryUsageLimit
		{
			get
			{
				if (Environment.GetEnvironmentVariable(""))
				{

				}
			}
		}
	}
}
