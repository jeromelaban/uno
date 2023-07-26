using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Uno.Extensions;
using Uno.UI.RemoteControl.HotReload.Messages;

[assembly: Uno.UI.RemoteControl.Host.ServerProcessorAttribute(typeof(Uno.UI.RemoteControl.Host.HotReload.XamlChangeProcessor))]

namespace Uno.UI.RemoteControl.Host.HotReload
{
	partial class XamlChangeProcessor : IServerProcessor, IDisposable
	{
		private readonly IRemoteControlServer _remoteControlServer;

		public XamlChangeProcessor(IRemoteControlServer remoteControlServer)
		{
			_remoteControlServer = remoteControlServer;
		}

		public string Scope => HotReloadConstants.TestingScopeName;

		public void Dispose()
		{
		}

		public Task ProcessFrame(Frame frame)
		{
			switch (frame.Name)
			{
				case nameof(ChangeXaml):
					ProcessChangeXaml(JsonConvert.DeserializeObject<ChangeXaml>(frame.Content)!);
					break;
			}

			return Task.CompletedTask;
		}

		private void ProcessChangeXaml(ChangeXaml changeXamlMessage)
		{
			if (changeXamlMessage?.IsValid() is not null &&
				File.Exists(changeXamlMessage.FilePath))
			{
				if (this.Log().IsEnabled(LogLevel.Debug))
				{
					this.Log().LogDebug($"Apply XAML Changes to {changeXamlMessage.FilePath}");
				}

				Console.WriteLine($"***PreApplyChanges***{changeXamlMessage.FilePath}");

				var originalXaml = File.ReadAllText(changeXamlMessage.FilePath);
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().LogTrace($"Original XAML: {changeXamlMessage.FilePath}");
				}

				var updatedXaml = originalXaml.Replace(changeXamlMessage.OriginalXaml, changeXamlMessage.ReplacementXaml);
				if (this.Log().IsEnabled(LogLevel.Trace))
				{
					this.Log().LogTrace($"Updated XAML: {changeXamlMessage.FilePath}");
				}

				File.WriteAllText(changeXamlMessage.FilePath, updatedXaml);
			}
		}
	}
}
