using DataEntities.Entities.Tardis;

namespace PeopleQueryHandler.Models;

public class PersonResponseModel : Person
{
    public PersonResponseModel() { }
    public PersonResponseModel(Person person) : base(person) { }
}
