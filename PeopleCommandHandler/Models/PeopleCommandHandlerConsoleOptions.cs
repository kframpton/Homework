using DataEntities.Contexts;
using ModuleSharedResources.Models;

namespace PeopleCommandHandler.Models;
public class PeopleCommandHandlerConsoleOptions : AModuleOptions
{
    public TardisContext Context { get; set; }
}
