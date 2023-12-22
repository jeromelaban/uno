#nullable enable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Uno.UI.RemoteControl.Messaging.IDEChannel;

internal interface IIDEChannelServer
{
	Task SendToIDEAsync(IDEMessage message);

	event EventHandler<IDEMessage>? MessageFromIDE;
	event EventHandler<IDEMessage>? MessageFromClient;
}

public record IDEMessage;

public record ForceHotReloadMessage : IDEMessage;

