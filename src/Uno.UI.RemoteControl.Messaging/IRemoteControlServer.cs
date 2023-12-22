using System.Threading.Tasks;
using Uno.UI.RemoteControl;
using Uno.UI.RemoteControl.HotReload.Messages;
using Uno.UI.RemoteControl.Messaging.IDEChannel;

namespace Uno.UI.RemoteControl.Host
{
	public interface IRemoteControlServer
	{
		string GetServerConfiguration(string key);

		Task SendFrame(IMessage fileReload);

		Task SendMessageToIDEAsync(IDEMessage message);
	}
}
