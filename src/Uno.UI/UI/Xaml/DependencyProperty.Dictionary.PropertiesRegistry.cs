#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.UI.Xaml;
using Uno.Extensions;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Uno;
using System.Threading;
using Uno.Collections;
using Uno.UI.Helpers;

namespace Microsoft.UI.Xaml
{
	public sealed partial class DependencyProperty
	{
		private class DependencyPropertyRegistry
		{
			private readonly HashtableEx _entries = new HashtableEx(FastTypeComparer.Default);

			internal bool TryGetValue(Type type, string name, out DependencyProperty? result)
			{
				if (TryGetTypeTable(type, out var typeTable))
				{
					if (typeTable!.TryGetValue(name, out var propertyObject))
					{
						result = (DependencyProperty)propertyObject!;
						return true;
					}
				}

				result = null;
				return false;
			}

			internal void Clear() => _entries.Clear();

			internal void Add(Type type, string name, DependencyProperty property)
			{
				if (!TryGetTypeTable(type, out var typeTable))
				{
					typeTable = new HashtableEx();
					_entries[type] = typeTable;
				}

				typeTable!.Add(name, property);
			}

			internal void AppendPropertiesForType(Type type, List<DependencyProperty> properties)
			{
				if (TryGetTypeTable(type, out var typeTable))
				{
					foreach(var value in typeTable!.Values)
					{
						properties.Add((DependencyProperty)value);
					}
				}
			}

			private bool TryGetTypeTable(Type type, out HashtableEx? table)
			{
				if (_entries.TryGetValue(type, out var dictionaryObject))
				{
					table = (HashtableEx)dictionaryObject!;
					return true;
				}

				table = null;
				return false;
			}
		}
	}
}
