using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ModuleSharedResources;
using PeopleQueryHandler.Console.Root;
using PeopleQueryHandler.Models;

namespace PeopleQueryHandler.Console.V1.R0;
public class Console : PeopleQueryHandlerConsole
{
    public Console() { }

    public Console(Action<PeopleQueryHandlerConsoleOptions> action) 
    {
        PeopleQueryHandlerConsoleOptions options = new();
        action(options);

        context = options.Context;
        logger = options.Services.GetService<ILogger<PeopleQueryHandlerConsole>>() ?? throw new LoggerNotProvidedException();
    }
}
