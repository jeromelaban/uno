#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.System.Diagnostics
{
	#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ProcessCpuUsage 
	{
		#if __ANDROID__ || __IOS__ || NET461 || __WASM__ || __NETSTD_REFERENCE__ || __MACOS__
		[global::Uno.NotImplemented]
		public  global::Windows.System.Diagnostics.ProcessCpuUsageReport GetReport()
		{
			throw new global::System.NotImplementedException("The member ProcessCpuUsageReport ProcessCpuUsage.GetReport() is not implemented in Uno.");
		}
		#endif
	}
}
