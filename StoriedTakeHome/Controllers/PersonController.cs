using DataEntities.Contexts;
using Microsoft.AspNetCore.Mvc;
using ModuleManager.Services;
using PeopleCommandHandler.Interfaces;
using PeopleCommandHandler.Models;
using PeopleQueryHandler.Interfaces;
using PeopleQueryHandler.Models;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPeopleCommandHandlerConsole commandHandler;
    private readonly IPeopleQueryHandlerConsole queryHandler;
    private readonly ILogger<PersonController> logger;

    public PersonController(IModuleManagerService moduleManagerService, TardisContext tardisContext, IServiceProvider services, ILogger<PersonController> logger)
    {
        commandHandler = moduleManagerService.GetApi<IPeopleCommandHandlerConsole, PeopleCommandHandlerConsoleOptions>(o =>
        {
            o.Context = tardisContext;
            o.Services = services;
        });
        queryHandler = moduleManagerService.GetApi<IPeopleQueryHandlerConsole, PeopleQueryHandlerConsoleOptions>(o =>
        {
            o.Context = tardisContext;
            o.Services = services;
        });
        this.logger = logger;
    }

    [ProducesResponseType(typeof(PersonResponseModel), 200),
        ProducesResponseType(404)]
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        logger.LogInformation("I've been asked to get the person entity for id: {id}", id);

        PersonResponseModel? person = queryHandler.GetPersonById(id);

        if (person == null)
            return NotFound();
        else
            return Ok(person);
    }

    [ProducesResponseType(typeof(PersonResponseModel), 201)]
    [HttpPost]
    public IActionResult Post([FromBody] AddPersonRequestModel personRequest)
    {
        logger.LogInformation("I've been asked to create a person entity");
        logger.LogDebug("entity: {@personRequest}", personRequest);

        PersonResponseModel person = new(commandHandler.AddPerson(personRequest));

        return Created($"http{(Request.IsHttps ? "s" : "")}://{Request.Host}{Request.Path}", person);
    }

    [ProducesResponseType(typeof(PersonResponseModel), 200)]
    [HttpPut]
    public IActionResult Put([FromBody] UpdatePersonRequestModel personRequest)
    {
        logger.LogInformation("I've been asked to update a person entity");
        logger.LogDebug("entity: {@personRequest}", personRequest);

        PersonResponseModel person = new(commandHandler.UpdatePerson(personRequest));

        return Ok(person);
    }
}
