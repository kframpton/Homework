namespace ModuleSharedResources.Interfaces;

public interface IModuleOptions
{
    double? Version { get; set; }
    IServiceProvider Services { get; set; }
}