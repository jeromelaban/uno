#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using Microsoft.Windows.Design;

namespace Uno.UI.Design
{
	internal class AttributeTableBuilder : Microsoft.Windows.Design.Metadata.AttributeTableBuilder
	{
		private Assembly? _unoUIAssembly;

		public AttributeTableBuilder()
		{
			TryResolveUnoAssembly();

			AddCustomAttributes(_unoUIAssembly,
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml", XamlConstants.BaseXamlNamespace) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.BaseXamlNamespace) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Controls) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Primitives) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Text) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Data) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Documents) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Media) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.MediaAnimation) { AssemblyName = "Uno.UI" },
				new XmlnsDefinitionAttribute("http://schemas.microsoft.com/winfx/2006/xaml/presentation", XamlConstants.Namespaces.Shapes) { AssemblyName = "Uno.UI" }
			);

			AddCallback(FindType("Windows.UI.Xaml.Style"), builder => builder.AddCustomAttributes(
			   new EditorBrowsableAttribute(EditorBrowsableState.Always),
			   new System.Windows.Markup.ContentPropertyAttribute("Setters"),
			   new System.ComponentModel.TypeConverterAttribute(typeof(StringConverter))));

			foreach(var contentType in FindAllContentPropertyControls())
			{
				AddContentProperty(contentType.controlType, contentType.propertyName);
			}
		}

		private void AddContentProperty(string controlName, string propertyName)
			=> AddContentProperty(FindType(controlName), propertyName);

		private void AddContentProperty(Type? controlType, string propertyName)
			=> AddCallback(
				controlType,
				builder => builder.AddCustomAttributes(
				   new EditorBrowsableAttribute(EditorBrowsableState.Always),
				   new System.Windows.Markup.ContentPropertyAttribute(propertyName)
				));

		private Type? FindType(string v)
			=> _unoUIAssembly?.GetType(v);

		private IEnumerable<(Type controlType, string propertyName)> FindAllContentPropertyControls()
		{
			TryResolveUnoAssembly();

			if (_unoUIAssembly != null)
			{
				var propertyType = _unoUIAssembly.GetType("Windows.UI.Xaml.Markup.ContentPropertyAttribute");
				var nameProperty = propertyType.GetProperty("Name");

				foreach (var type in _unoUIAssembly.GetTypes())
				{
					if (type.GetCustomAttribute(propertyType) is Attribute contentPropertyAttribute)
					{
						yield return (type, (string)nameProperty.GetValue(contentPropertyAttribute));
					}
				}
			}
		}

		private void TryResolveUnoAssembly()
			=> _unoUIAssembly ??= AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => string.Equals(a.GetName().Name, "Uno.UI", StringComparison.OrdinalIgnoreCase));

		internal static class XamlConstants
		{
			public const string RootUINamespace = "Windows.UI";
			public const string BaseXamlNamespace = RootUINamespace + ".Xaml";

			internal static class Namespaces
			{
				public const string Controls = BaseXamlNamespace + ".Controls";
				public const string Primitives = Controls + ".Primitives";
				public const string Text = RootUINamespace + ".Text";
				public const string Data = BaseXamlNamespace + ".Data";
				public const string Documents = BaseXamlNamespace + ".Documents";
				public const string Media = BaseXamlNamespace + ".Media";
				public const string MediaAnimation = BaseXamlNamespace + ".Media.Animation";
				public const string Shapes = BaseXamlNamespace + ".Shapes";

			}
		}
	}

	internal class AnythingConverter : System.ComponentModel.TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return true;
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return true;
		}

		public override bool IsValid(ITypeDescriptorContext context, object value)
		{
			return true;
		}
	}
}
