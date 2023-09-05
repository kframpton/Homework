using DataEntities.Entities.Tardis;
using ModuleSharedResources.Interfaces;
using PeopleQueryHandler.Models;

namespace PeopleQueryHandler.Interfaces;
public interface IPeopleQueryHandlerConsole : IManagedModule
{
    List<PersonResponseModel> GetAllPeople();
    List<PersonResponseModel> GetAllPeople(Gender gender);
    List<PersonResponseModel> GetAllPeopleByGivenName(string givenName);
    List<PersonResponseModel> GetAllPeopleBySurname(string surname);
    PersonResponseModel? GetPersonById(Guid id);
    List<PersonHistoryResponseModel> GetPersonHistory(Guid id);
}
