using DataEntities.Contexts;
using DataEntities.Entities.Tardis;
using Microsoft.Extensions.Logging;
using ModuleSharedResources.Apis;
using PeopleCommandHandler.Interfaces;
using PeopleCommandHandler.Models;

namespace PeopleCommandHandler.Console.Root;
public abstract partial class PeopleCommandHandlerConsole : ABaseConsole, IPeopleCommandHandlerConsole
{
    protected TardisContext context;
    protected ILogger<PeopleCommandHandlerConsole> logger;

    public virtual Person AddPerson(AddPersonRequestModel personRequest)
    {
        logger.LogInformation("Adding person entity");
        logger.LogDebug("personRequest: {@personRequest}", personRequest);
        if (!personRequest.Validate(out string error))
            throw new AddPersonException($"Validation failed: {error}");

        Person person = new()
        {
            Id = Guid.NewGuid(),
            GivenName = personRequest.GivenName,
            Surname = personRequest.Surname,
            Gender = personRequest.Gender,
            BirthDate = personRequest.BirthDate,
            BirthLocation = personRequest.BirthLocation,
            DeathDate = personRequest.DeathDate,
            DeathLocation = personRequest.DeathLocation
        };

        context.People.Add(person);
        context.SaveChanges();

        context.PeopleHistory.Add(new(person));
        context.SaveChanges();
        return person;
    }

    public virtual Person RecordBirth(RecordBirthRequestModel birthRequest)
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
}
