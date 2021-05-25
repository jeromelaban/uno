// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;

namespace Uno.UI.Runtime.Skia.Native
{
	[StructLayout(LayoutKind.Sequential)]
	struct pollfd
	{
		public int fd;         /* file descriptor */
		public short events;     /* requested events */
		public short revents;    /* returned events */
	};
}
