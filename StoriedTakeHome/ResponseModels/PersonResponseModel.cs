using DataEntities.Entities.Tardis;

namespace StoriedTakeHomeWebApi.ResponseModels;

public class PersonResponseModel : Person
{
    public PersonResponseModel() { }
    public PersonResponseModel(Person person) : base(person) { }
}
