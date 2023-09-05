using DataEntities.Contexts;
using DataEntities.Entities.Tardis;
using Framptonius.BasicExtensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModuleManager.Models;
using ModuleSharedResources.Interfaces;
using ModuleSharedResources.Models;

namespace ModuleManager.Services;

public class ModuleManagerService : IModuleManagerService
{
    TardisContext Context { get; set; }
    public List<ApiVersion> ApiRoster { get; set; } = new List<ApiVersion>();
    public IMemoryCache Cache { get; private set; }
    public ILogger<ModuleManagerService> Logger { get; set; }
    public ModuleManagerOptions Options { get; set; }
    public List<ModuleVersion> ModuleVersions { get; set; }
    public List<Module> Modules
    {
        get
        {
            if (Cache.TryGetValue("Modules", out object? modules) && modules is List<Module>)
            {
                return (List<Module>)modules;
            }
            else
            {
                Logger.LogDebug("Module list not cached, retrieving list");
                modules = Context.Modules.ToList();
                Logger.LogDebug("Caching module list {@modules}", modules);
                Cache.Set("Modules", modules, new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(Options.SlidingExpiration))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(Options.AbsoluteExpiration)));
            }

            return (List<Module>)modules;
        }
    }


    public ModuleManagerService(TardisContext tardisContext,
                                IMemoryCache cache,
                                ILogger<ModuleManagerService> logger,
                                IOptions<ModuleManagerOptions> optionsAccessor,
                                IConfiguration configuration)
    {
        Context = tardisContext;
        Cache = cache;
        Logger = logger;
        ModuleManagerOptions? options = configuration.GetSection("ModuleManagement").Get<ModuleManagerOptions>();
        ModuleVersions = configuration.GetSection("ModuleVersions").Get<List<ModuleVersion>>() ?? new();

        if (options is not null)
        {
            Options = options;
        }
        else
        {
            Options = optionsAccessor.Value;
        }
    }

    internal void VerifyDeprecationLevel(string library, double version)
    {
        try
        {
            if (Modules.Where(c => c.Name == library).Single().Invalid(version))
                throw new OutdatedModuleException("This module is outdated and can no longer be used.", library, version);
        }
        catch (Exception ex)
        {
            throw new BadModuleException(ex, library, version);
        }
    }

    public T GetApi<T, T2>(Action<T2> moduleOptions)
        where T : IManagedModule
        where T2 : AModuleOptions, new()
    {
        T2 options = new();
        moduleOptions(options);

        string name = typeof(T).Assembly.GetName().Name ?? throw new ModuleNameException();

        if (options.Version == null)
        {
            Module module = Modules.Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Single();
            ModuleVersion? moduleVersion = ModuleVersions.Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).SingleOrDefault();

            options.Version ??= moduleVersion?.Version ?? module.DefaultVersion;
        }

        VerifyDeprecationLevel(name, (double)options.Version);

        return GetApi<T, T2>(name, (double)options.Version, moduleOptions);
    }

    public T GetApi<T, T2>(string module, double version, Action<T2> moduleOptions) where T : IManagedModule
    {
        ApiVersion? result = ApiRoster
            .Where(c => c.Library.Equals(module, StringComparison.OrdinalIgnoreCase) && c.Version.Equals(version))
            .FirstOrDefault();

        if (result != null)
        {
            IManagedModule Console = result.Console;
            return (T)Console;
        }
        else
        {
            ApiRoster.Add(new ApiVersion(module, version, GetModuleConsole<IManagedModule, T2>(module, version, moduleOptions)));
            return GetApi<T, T2>(module, version, moduleOptions);
        }
    }

    public T GetModuleConsole<T, T2>(string module, double version, Action<T2> moduleOptions) where T : IManagedModule
    {
        BadModuleException badModule = new("Unable to locate module.", module, version);
        BadModuleVersionException badModuleVersion = new("Unable to determine module version.", module, version);

        try
        {
            List<int> versionInts = version.SplitTheDots();

            if (versionInts.Count != 2)
                throw badModuleVersion;

            string name = $"{module}.Console.V{versionInts[0]}.R{versionInts[1]}.Console";
            System.Reflection.Assembly assembly;

            assembly = System.Reflection.Assembly.Load(module);
            Type? type = assembly.GetType(name);

            if (type == null)
            {
                throw badModule;
            }
            else
            {
                T? mod = (T?)Activator.CreateInstance(type, moduleOptions);
                return mod ?? throw badModule;
            }
        }
        catch (Exception ex)
        {
            throw new BadModuleException(ex, "Unable to locate module.", module, version);
        }
    }
}