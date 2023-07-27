using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Uno.Extensions;

namespace Uno.UI.RemoteControl.HotReload.Messages
{
	internal class HotReloadWorkspaceLoadResult : IMessage
	{
		public const string Name = nameof(ChangeXaml);

		[JsonProperty]
		public bool WorkspaceInitialized { get; set; }

		[JsonIgnore]
		public string Scope => HotReloadConstants.TestingScopeName;

		[JsonIgnore]
		string IMessage.Name => Name;
	}
}
