using DataEntities.Entities.Tardis;
using ModuleSharedResources.Apis;
using PeopleCommandHandler.Interfaces;
using PeopleCommandHandler.Models;

namespace PeopleCommandHandler.Console.Root;
public abstract partial class PeopleCommandHandlerConsole : ABaseConsole, IPeopleCommandHandlerConsole
{
    public virtual Person RecordDeath(RecordDeathRequestModel deathRequest) => throw NotInVersion(this);
    public virtual Person UpdatePerson(UpdatePersonRequestModel personRequest) => throw NotInVersion(this);
}
