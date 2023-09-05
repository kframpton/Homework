using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PeopleCommandHandler.Console.Root;
using PeopleCommandHandler.Models;
using ModuleSharedResources;

namespace PeopleCommandHandler.Console.V1.R0;
public class Console : PeopleCommandHandlerConsole
{
    public Console() { }

    public Console(Action<PeopleCommandHandlerConsoleOptions> action)
    {
        PeopleCommandHandlerConsoleOptions options = new();
        action(options);

        context = options.Context;
        logger = options.Services.GetService<ILogger<PeopleCommandHandlerConsole>>() ?? throw new LoggerNotProvidedException();
    }
}
