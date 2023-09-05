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
public class BirthController : ControllerBase
{
    private readonly IPeopleCommandHandlerConsole commandHandler;
    private readonly ILogger<PersonController> logger;

    public BirthController(IModuleManagerService moduleManagerService, TardisContext tardisContext, IServiceProvider services, ILogger<PersonController> logger)
    {
        commandHandler = moduleManagerService.GetApi<IPeopleCommandHandlerConsole, PeopleCommandHandlerConsoleOptions>(o =>
        {
            o.Context = tardisContext;
            o.Services = services;
        });
        this.logger = logger;
    }

    [ProducesResponseType(typeof(PersonResponseModel), 200)]
    [HttpPut]
    public IActionResult Put([FromBody] RecordBirthRequestModel birthRequest)
    {
        logger.LogInformation("I've been told someone had a baby");
        logger.LogDebug("entity: {@birthRequest}", birthRequest);

        PersonResponseModel person = new(commandHandler.RecordBirth(birthRequest));

        return Ok(person);
    }
}
