using ModuleSharedResources.Apis;
using PeopleQueryHandler.Interfaces;
using PeopleQueryHandler.Models;

namespace PeopleQueryHandler.Console.Root;
public abstract partial class PeopleQueryHandlerConsole : ABaseConsole, IPeopleQueryHandlerConsole
{
    public virtual List<PersonHistoryResponseModel> GetPersonHistory(Guid id) => throw NotInVersion(this);
}
