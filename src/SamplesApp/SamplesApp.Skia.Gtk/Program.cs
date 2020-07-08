using System;
using GLib;
using SkiaSharp;
using Gtk;
using Uno.Foundation.Extensibility;
using System.Threading;

namespace SkiaSharpExample
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Gtk.Application.Init();

			ApiExtensibility.Register(typeof(Windows.UI.Core.ICoreWindowExtension), o => new Uno.UI.Skia.Platform.GTK.GtkUIElementPointersSupport(o));

			ExceptionManager.UnhandledException += delegate (UnhandledExceptionArgs expArgs)
			{
				Console.WriteLine("GLIB UNHANDLED EXCEPTION" + expArgs.ExceptionObject.ToString());
				expArgs.ExitApplication = true;
			};

			var host = new Uno.UI.Skia.Platform.GTK.GtkHost(() => new SamplesApp.App(), args);

			host.Run();
		}
	}
}
