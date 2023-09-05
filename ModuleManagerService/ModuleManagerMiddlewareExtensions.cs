using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using ModuleManager.Models;
using ModuleManager.Services;
using Serilog;

namespace ModuleManager
{
    public static class ModuleManagerMiddlewareExtensions
	{
		public static IApplicationBuilder UseModuleManagerService(this IApplicationBuilder builder) =>
			builder.UseMiddleware<ModuleManagerMiddleware>();

		/// <summary>
		/// Adds the ModuelManager dynamic module management service
		/// </summary>
		/// <param name="services"></param>
		/// <param name="options"></param>
		/// <remarks>Requires IMemoryCache to be added to the IServiceCollection and will add it if it doesn't already exist</remarks>
		public static void AddModuleManager(this IServiceCollection services, Action<ModuleManagerOptions>? options = null)
		{
			if (options != null)
				services.Configure(options);

			if (!services.Any(c => c.ServiceType == typeof(IMemoryCache)))
				services.AddMemoryCache();

			services.AddScoped<IModuleManagerService, ModuleManagerService>();
		}

		/// <summary>
		/// Adds the ModuelManager dynamic module management service
		/// </summary>
		/// <param name="builder"></param>
		/// <param name="options"></param>
		/// <remarks>Requires IMemoryCache to be added to the IServiceCollection and will add it if it doesn't already exist</remarks>
		/// <returns>The same WebApplicationBuilder object to allow chaining</returns>
		public static WebApplicationBuilder AddModuleManager(this WebApplicationBuilder builder, Action<ModuleManagerOptions>? options = null)
        {
			Log.Information("Adding ModuleManager");
			builder.Services.AddModuleManager(options);

			return builder;
        }
	}
}
