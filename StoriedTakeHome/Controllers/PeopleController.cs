using DataEntities.Entities.Tardis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using StoriedTakeHomeWebApi.Interfaces.Queries;
using StoriedTakeHomeWebApi.RequestModels;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPersonQueryHandler queryHandler;
    private readonly ILogger<PeopleController> logger;

    public PeopleController(IPersonQueryHandler queryHandler, ILogger<PeopleController> logger)
    {
        this.queryHandler = queryHandler;
        this.logger = logger;
    }

    [ProducesResponseType(typeof(IEnumerable<PersonResponseModel>), 200),
        ProducesResponseType(404)]
    [HttpGet]
    public IActionResult Get()
    {
        logger.LogInformation("Somebody wants to get to know everybody");

        IEnumerable<PersonResponseModel> people = queryHandler.GetAllPeople();

        if (!people.Any())
            return NotFound();
        else
            return Ok(people);
    }

    [ProducesResponseType(typeof(PersonResponseModel), 200),
        ProducesResponseType(404)]
    [HttpGet("{gender}")]
    public IActionResult Get(Gender gender)
    {
        logger.LogInformation("Somebody wants to get to know all the {gender} people", gender);

        IEnumerable<PersonResponseModel> people = queryHandler.GetAllPeople(gender);

        if (!people.Any())
            return NotFound();
        else
            return Ok(people);
    }

    [ProducesResponseType(typeof(PersonResponseModel), 200),
        ProducesResponseType(404)]
    [HttpGet("{name}/{type}")]
    public IActionResult GetByName(string name, NameRequestType type)
    {
        logger.LogInformation("Somebody wants to get to know everyone with the {type} {name}", type.GetDisplayName(), name);

        IEnumerable<PersonResponseModel>? people = type switch
        {
            NameRequestType.GivenName => queryHandler.GetAllPeopleByGivenName(name),
            NameRequestType.Surname => queryHandler.GetAllPeopleBySurname(name),
            _ => null
        };        

        if (people?.Any() != true)
            return NotFound();
        else
            return Ok(people);
    }
}
