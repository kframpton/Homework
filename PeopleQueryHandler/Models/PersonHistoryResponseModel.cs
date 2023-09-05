using DataEntities.Entities.Tardis;

namespace PeopleQueryHandler.Models;

public class PersonHistoryResponseModel : PersonHistory
{
    public PersonHistoryResponseModel() { }
    public PersonHistoryResponseModel(PersonHistory history) : base(history) { }
}
