using DataEntities.Entities.Tardis;

namespace PeopleCommandHandler.Models;

public class AddPersonRequestModel
{
    public string? GivenName { get; set; }
    public string? Surname { get; set; }
    public Gender? Gender { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? BirthLocation { get; set; }
    public DateTime? DeathDate { get; set; }
    public string? DeathLocation { get; set; }
}

public static class AddPersonRequestModelExtensions
{
    public static bool Validate(this AddPersonRequestModel person, out string error)
    {
        if (person.GivenName is null && person.Surname is null)
        {
            error = "Either GivenName OR Surname must be provided";
            return false;
        }

        if (person.Gender is null)
        {
            error = "Gender must be provided";
            return false;
        }

        error = "";
        return true;
    }
}
