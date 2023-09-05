using DataEntities.Contexts;
using Microsoft.AspNetCore.Mvc;
using ModuleManager.Services;
using PeopleCommandHandler.Interfaces;
using PeopleCommandHandler.Models;
using PeopleQueryHandler.Models;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class DeathController : ControllerBase
{
    private readonly IPeopleCommandHandlerConsole commandHandler;
    private readonly ILogger<PersonController> logger;

    public DeathController(IModuleManagerService moduleManagerService, TardisContext tardisContext, IServiceProvider services, ILogger<PersonController> logger)
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
    public IActionResult Put([FromBody] RecordDeathRequestModel deathRequest)
    {
        logger.LogInformation("Sadly I've been told someone has passed away");
        logger.LogDebug("entity: {@deathRequest}", deathRequest);

        PersonResponseModel person = new(commandHandler.RecordDeath(deathRequest));

        return Ok(person);
    }
}
