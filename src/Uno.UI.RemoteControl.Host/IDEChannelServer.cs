using System;
using System.IO.Pipes;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StreamJsonRpc;
using Uno.UI.RemoteControl.Messaging.IDEChannel;

namespace Uno.UI.RemoteControl.Host;

internal class IDEChannelServer : Messaging.IDEChannel.IIDEChannelServer
{
	private IServiceProvider _serviceProvider;

	public IDEChannelServer(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public event EventHandler<IDEMessage>? MessageFromIDE;

	public event EventHandler<IDEMessage>? MessageFromClient;

	public async Task SendToIDEAsync(IDEMessage message)
	{
		MessageFromClient?.Invoke(this, message);

		await Task.Yield();
	}

	public async Task SendToDevServerAsync(IDEMessage message)
	{
		MessageFromIDE?.Invoke(this, message);

		await Task.Yield();
	}
}

internal interface IIDEChannelServerProvider
{
	Task<IIDEChannelServer?> GetIDEChannelServerAsync();
}

internal class IDEChannelServerProvider : IIDEChannelServerProvider
{
	private readonly ILogger _logger;
	private readonly IConfiguration _configuration;
	private readonly IServiceProvider _serviceProvider;
	private readonly Task<IDEChannelServer?> _initializeTask;
	private NamedPipeServerStream? _pipeServer;
	private IDEChannelServer? _ideChannelServer;
	private JsonRpc? _rpcServer;

	public IDEChannelServerProvider(ILogger<IDEChannelServerProvider> logger, IConfiguration configuration, IServiceProvider serviceProvider)
	{
		_logger = logger;
		_configuration = configuration;
		_serviceProvider = serviceProvider;

		_initializeTask = Task.Run(Initialize);
	}

	private async Task<IDEChannelServer?> Initialize()
	{
		if (!Guid.TryParse(_configuration["ideChannel"], out var ideChannel))
		{
			_logger.LogDebug("No IDE Channel ID specified, skipping");
			return null;
		}

		_pipeServer = new NamedPipeServerStream(
			pipeName: ideChannel.ToString(),
			direction: PipeDirection.InOut,
			maxNumberOfServerInstances: 1,
			transmissionMode: PipeTransmissionMode.Byte,
			options: PipeOptions.Asynchronous | PipeOptions.WriteThrough);

		if (_logger.IsEnabled(LogLevel.Debug))
		{
			_logger.LogDebug("Waiting for IDE connection");
		}

		await _pipeServer.WaitForConnectionAsync();

		if (_logger.IsEnabled(LogLevel.Debug))
		{
			_logger.LogDebug("IDE Connected");
		}

		_ideChannelServer = new IDEChannelServer(_serviceProvider);
		_rpcServer = JsonRpc.Attach(_pipeServer, _ideChannelServer);

		_ = Task.Run(async () => {
			_logger.LogDebug("Before sending");

			await Task.Delay(5000);
			_logger.LogDebug("Sending");
			await _ideChannelServer.SendToIDEAsync(new ForceHotReloadMessage());
			_logger.LogDebug("After sending");
		});
		

		return _ideChannelServer;
	}

	public async Task<IIDEChannelServer?> GetIDEChannelServerAsync()
	{
#pragma warning disable IDE0022 // Use expression body for method
#pragma warning disable VSTHRD003 // Avoid awaiting foreign Tasks
		return await _initializeTask;
#pragma warning restore VSTHRD003 // Avoid awaiting foreign Tasks
#pragma warning restore IDE0022 // Use expression body for method
	}
}
