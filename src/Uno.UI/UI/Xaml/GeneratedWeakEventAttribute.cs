#nullable enable

using System;

namespace Uno.UI.Xaml
{
	/// <summary>
	/// Attribute to control the automatic generation of dependency property generation
	/// </summary>
	[System.AttributeUsage(AttributeTargets.Event, Inherited = false, AllowMultiple = false)]
	internal sealed class GeneratedWeakEventAttribute : Attribute
	{

	}
}
