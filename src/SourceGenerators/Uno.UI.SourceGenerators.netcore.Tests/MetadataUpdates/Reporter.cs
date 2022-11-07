using Uno.UI.RemoteControl.Host.HotReload.MetadataUpdates;

namespace Uno.UI.SourceGenerators.MetadataUpdates;

internal class Reporter : IReporter
{
	public void Error(string message) { }
	public void Output(string message)  { }
	public void Verbose(string message)  { }
	public void Warn(string message) { }
}
