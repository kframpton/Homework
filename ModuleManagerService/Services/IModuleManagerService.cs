using ModuleSharedResources.Interfaces;
using ModuleSharedResources.Models;

namespace ModuleManager.Services
{
    public interface IModuleManagerService
	{
		T GetApi<T, T2>(Action<T2> moduleOptions)
			where T : IManagedModule
			where T2 : AModuleOptions, new();
		T GetApi<T, T2>(string module, double version, Action<T2> moduleOptions) where T : IManagedModule;
		T GetModuleConsole<T, T2>(string module, double version, Action<T2> moduleOptions) where T : IManagedModule;
	}
}
