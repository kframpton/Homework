using DataEntities.Entities.Tardis;
using ModuleSharedResources.Interfaces;
using PeopleCommandHandler.Models;

namespace PeopleCommandHandler.Interfaces;
public interface IPeopleCommandHandlerConsole : IManagedModule
{
    Person AddPerson(AddPersonRequestModel personRequest);
    Person RecordBirth(RecordBirthRequestModel birthRequest);
    Person RecordDeath(RecordDeathRequestModel deathRequest);
    Person UpdatePerson(UpdatePersonRequestModel personRequest);
}
