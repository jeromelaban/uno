using System;
using Microsoft/* UWP don't rename */.UI.Xaml;

namespace $ext_safeprojectname$.Wasm
{
	public sealed class Program
	{
		private static App _app;

		static int Main(string[] args)
		{
			Microsoft/* UWP don't rename */.UI.Xaml.Application.Start(_ => _app = new AppHead());

			return 0;
		}
	}
}
