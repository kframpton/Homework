using DataEntities.Contexts;
using DataEntities.Entities.Tardis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;
using ModuleManager.Services;
using PeopleQueryHandler.Interfaces;
using PeopleQueryHandler.Models;
using StoriedTakeHomeWebApi.RequestModels;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPeopleQueryHandlerConsole queryHandler;
    private readonly ILogger<PeopleController> logger;

    public PeopleController(IModuleManagerService moduleManagerService, TardisContext tardisContext, IServiceProvider services, ILogger<PeopleController> logger)
    {
        queryHandler = moduleManagerService.GetApi<IPeopleQueryHandlerConsole, PeopleQueryHandlerConsoleOptions>(o =>
        {
            o.Context = tardisContext;
            o.Services = services;
        });
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
