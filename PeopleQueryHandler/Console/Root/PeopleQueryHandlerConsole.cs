using DataEntities.Contexts;
using DataEntities.Entities.Tardis;
using Microsoft.Extensions.Logging;
using ModuleSharedResources.Apis;
using PeopleQueryHandler.Interfaces;
using PeopleQueryHandler.Models;

namespace PeopleQueryHandler.Console.Root;
public abstract partial class PeopleQueryHandlerConsole : ABaseConsole, IPeopleQueryHandlerConsole
{
    protected TardisContext context;
    protected ILogger<PeopleQueryHandlerConsole> logger;

    public virtual PersonResponseModel? GetPersonById(Guid id)
    {
        logger.LogInformation("Getting person entity for id: {id}", id);
        Person? person = context.People.FirstOrDefault(c => c.Id == id);

        if (person is not null)
        {
            logger.LogInformation("Person entity found!");
            logger.LogDebug("person: {@person}", person);
            return new(person);
        }
        else
        {
            logger.LogInformation("Person entity doesn't exist");
            return null;
        }
    }

    public virtual List<PersonResponseModel> GetAllPeople()
    {
        List<PersonResponseModel> people = new();
        logger.LogInformation("Getting every person entity there is");
        if (context.People.Any())
            foreach (Person person in context.People)
                people.Add(new(person));

        if (people.Count > 0)
        {
            logger.LogInformation("People entities found!");
            logger.LogDebug("people: {@people}", people);
        }
        else
        {
            logger.LogInformation("No people found, it's very empty in here");
        }

        return people;
    }

    public virtual List<PersonResponseModel> GetAllPeople(Gender gender)
    {
        List<PersonResponseModel> people = new();
        logger.LogInformation("Getting every person entity of gender {gender} there is", gender);
        if (context.People.Any(c => c.Gender == gender))
            foreach (Person person in context.People.Where(c => c.Gender == gender))
                people.Add(new(person));

        if (people.Count > 0)
        {
            logger.LogInformation("{gender} people entities found!", gender);
            logger.LogDebug("people: {@people}", people);
        }
        else
        {
            logger.LogInformation("There are no {gender} people here", gender);
        }

        return people;
    }

    public virtual List<PersonResponseModel> GetAllPeopleByGivenName(string givenName)
    {
        List<PersonResponseModel> people = new();
        logger.LogInformation("Getting every person entity with given name of {givenName} we can find", givenName);
        if (context.People.Any(c => c.GivenName == givenName))
            foreach (Person person in context.People.Where(c => c.GivenName == givenName))
                people.Add(new(person));

        if (people.Count > 0)
        {
            logger.LogInformation($"We found {(people.Count > 1 ? "just one {givenName}" : "at least a few {givenName}s")}", givenName);
            logger.LogDebug("people: {@people}", people);
        }
        else
        {
            logger.LogInformation("There are no {givenName}s here", givenName);
        }

        return people;
    }

    public virtual List<PersonResponseModel> GetAllPeopleBySurname(string surname)
    {
        List<PersonResponseModel> people = new();
        logger.LogInformation("Getting every person entity with given name of {surname} we can find", surname);
        if (context.People.Any(c => c.Surname == surname))
            foreach (Person person in context.People.Where(c => c.Surname == surname))
                people.Add(new(person));

        if (people.Count > 0)
        {
            logger.LogInformation($"We found {(people.Count > 1 ? "just one {surname}" : "at least a few {surname}s")}", surname);
            logger.LogDebug("people: {@people}", people);
        }
        else
        {
            logger.LogInformation("There are no {surname}s here", surname);
        }

        return people;
    }
}
