using DataEntities.Entities.Tardis;
using StoriedTakeHomeWebApi.RequestModels;

namespace StoriedTakeHomeWebApi.Interfaces.Commands;

public interface IPersonCommandHandler
{
    Person AddPerson(AddPersonRequestModel personRequest);
    Person RecordBirth(RecordBirthRequestModel birthRequest);
    Person RecordDeath(RecordDeathRequestModel deathRequest);
    Person UpdatePerson(UpdatePersonRequestModel personRequest);
}
