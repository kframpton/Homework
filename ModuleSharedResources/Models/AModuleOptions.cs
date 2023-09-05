using ModuleSharedResources.Interfaces;

namespace ModuleSharedResources.Models;

public abstract class AModuleOptions : IModuleOptions
{
	public virtual double? Version { get; set; }
	public IServiceProvider Services { get; set; }
}