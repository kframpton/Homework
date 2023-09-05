using DataEntities.Entities.Tardis;
using Microsoft.Extensions.Logging;
using PeopleCommandHandler.Models;

namespace PeopleCommandHandler.Console.V1.R1;
public class Console : R0.Console
{
    public Console() { }

    public Console(Action<PeopleCommandHandlerConsoleOptions> action) : base(action) { }

    //this is actually the same as version 1.0 but included for demo purposes
    public override Person RecordBirth(RecordBirthRequestModel birthRequest)
    {
        logger.LogInformation("Recording birth");
        logger.LogDebug("birthRequest: {@birthRequest}", birthRequest);

        if (!birthRequest.Validate(out string error))
            throw new AddPersonException($"Validation failed: {error}");

        Person person = context.People.FirstOrDefault(c => c.Id == birthRequest.Id) ?? throw new PersonException();

        if (birthRequest.BirthDate != null || birthRequest.BirthLocation != null)
        {
            context.PeopleHistory.Add(new(person));

            if (birthRequest.BirthDate != null)
                person.BirthDate = birthRequest.BirthDate;
            if (birthRequest.BirthLocation != null)
                person.BirthLocation = birthRequest.BirthLocation;

            context.SaveChanges();
        }

        return person;
    }

    public override Person RecordDeath(RecordDeathRequestModel deathRequest)
    {
        logger.LogInformation("Recording death");
        logger.LogDebug("deathRequest: {@deathRequest}", deathRequest);

        if (!deathRequest.Validate(out string error))
            throw new AddPersonException($"Validation failed: {error}");

        Person person = context.People.FirstOrDefault(c => c.Id == deathRequest.Id) ?? throw new PersonException();

        if (deathRequest.DeathDate != null || deathRequest.DeathLocation != null)
        {
            context.PeopleHistory.Add(new(person));

            if (deathRequest.DeathDate != null)
                person.DeathDate = deathRequest.DeathDate;
            if (deathRequest.DeathLocation != null)
                person.DeathLocation = deathRequest.DeathLocation;

            context.SaveChanges();
        }

        return person;
    }

    public override Person UpdatePerson(UpdatePersonRequestModel personRequest)
    {
        logger.LogInformation("Updating person entity");
        logger.LogDebug("personRequest: {@personRequest}", personRequest);

        Person person = context.People.FirstOrDefault(c => c.Id == personRequest.Id) ?? throw new PersonException();

        context.PeopleHistory.Add(new(person));

        person.GivenName = personRequest.GivenName;
        person.Surname = personRequest.Surname;
        person.Gender = personRequest.Gender;
        person.BirthDate = personRequest.BirthDate;
        person.BirthLocation = personRequest.BirthLocation;
        person.DeathDate = personRequest.DeathDate;
        person.DeathLocation = personRequest.DeathLocation;

        context.SaveChanges();

        return person;
    }
}
