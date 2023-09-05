using Microsoft.AspNetCore.Http;
using ModuleManager.Services;

namespace ModuleManager
{
    public class ModuleManagerMiddleware
	{
		private readonly RequestDelegate next;

		public ModuleManagerMiddleware(RequestDelegate n)
		{
			next = n;
		}

		public Task InvokeAsync(HttpContext context, IModuleManagerService service)
		{
			return next(context);
		}
	}
}
