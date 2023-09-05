using DataEntities.Entities.Tardis;

namespace StoriedTakeHomeWebApi.RequestModels;

public class UpdatePersonRequestModel : Person
{
    public UpdatePersonRequestModel() { }

    public UpdatePersonRequestModel(string givenName, string surname) 
        : base(new Person()
        {
            GivenName = givenName,
            Surname = surname
        })
    { }

    public UpdatePersonRequestModel(string givenName, string surname, Gender gender, DateTime birthDate, DateTime? deathDate = null, string? deathLocation = null) 
        : base(new()
        {
            GivenName = givenName,
            Surname = surname,
            Gender = gender,
            BirthDate = birthDate,
            DeathDate = deathDate,
            DeathLocation = deathLocation
        })
    { }

    public UpdatePersonRequestModel(Person person) : base(person) { }    
}