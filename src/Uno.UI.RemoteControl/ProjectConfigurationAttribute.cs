using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Uno.UI.RemoteControl
{
	[System.AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
	public sealed class ProjectConfigurationAttribute : Attribute
	{
		public ProjectConfigurationAttribute(string projectPath, string[] xamlPaths/*, bool metadataUpdateEnabled*/)
		{
			ProjectPath = projectPath;
			XamlPaths = xamlPaths;
			/*MetadataUpdateEnabled = metadataUpdateEnabled;*/
		}

		public string ProjectPath { get; }

		public string[] XamlPaths { get; }

		//public bool MetadataUpdateEnabled { get; }
	}
}
