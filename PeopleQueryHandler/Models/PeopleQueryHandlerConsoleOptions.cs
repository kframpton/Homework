using DataEntities.Contexts;
using ModuleSharedResources.Models;

namespace PeopleQueryHandler.Models;
public class PeopleQueryHandlerConsoleOptions : AModuleOptions
{
    public TardisContext Context { get; set; }
}
