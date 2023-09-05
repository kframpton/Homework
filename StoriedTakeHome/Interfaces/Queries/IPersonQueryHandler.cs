using DataEntities.Entities.Tardis;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Interfaces.Queries;

public interface IPersonQueryHandler
{
    PersonResponseModel? GetPersonById(Guid id);
    List<PersonResponseModel> GetAllPeople();
    List<PersonResponseModel> GetAllPeople(Gender gender);
    List<PersonResponseModel> GetAllPeopleByGivenName(string givenName);
    List<PersonResponseModel> GetAllPeopleBySurname(string surname);
    List<PersonHistoryResponseModel> GetPersonHistory(Guid id);
}
