#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.UI.SourceGenerators.XamlGenerator
{
	internal class NameScope
	{
		public NameScope(string? @namespace, string className)
		{
			Namespace = @namespace ?? string.Empty;
			ClassName = className;
		}

		public string Name => $"{Namespace.Replace(".", "")}{ClassName}";
		public string Namespace { get; private set; }
		public string ClassName { get; private set; }

		public List<BackingFieldDefinition> BackingFields { get; } = new List<BackingFieldDefinition>();

		/// <summary>
		/// List of action handlers for registering x:Bind events
		/// </summary>
		public List<BackingFieldDefinition> xBindEventsHandlers { get; } = new List<BackingFieldDefinition>();

		/// <summary>
		/// Lists the ElementStub builder holder variables used to pin references for implicit pinning platforms
		/// </summary>
		public List<string> ElementStubHolders { get; } = new List<string>();

		public HashSet<string> ReferencedElementNames { get; } = new HashSet<string>();

		public Dictionary<string, Subclass> Subclasses { get; } = new Dictionary<string, Subclass>();

		public List<XamlObjectDefinition> Components { get; } = new List<XamlObjectDefinition>();

		public List<XamlObjectDefinition> XBindExpressions { get; } = new List<XamlObjectDefinition>();

		public int ComponentCount => Components.Count;
	}

	internal class XLoadScope
	{
		public List<ComponentEntry> Components { get; } = new List<ComponentEntry>();
		public int ComponentCount => Components.Count;

		/// <summary>
		/// List of action handlers for registering x:Bind events
		/// </summary>
		public List<BackingFieldDefinition> xBindEventsHandlers { get; } = new List<BackingFieldDefinition>();

	}

	internal class ComponentEntry
	{
		public ComponentEntry(string variableName, XamlObjectDefinition objectDefinition)
		{
			VariableName = variableName;
			ObjectDefinition = objectDefinition;
		}

		public string VariableName { get; }
		public XamlObjectDefinition ObjectDefinition { get; }
	}
}
