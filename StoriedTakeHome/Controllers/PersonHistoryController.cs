using DataEntities.Contexts;
using Microsoft.AspNetCore.Mvc;
using ModuleManager.Services;
using PeopleQueryHandler.Interfaces;
using PeopleQueryHandler.Models;

namespace StoriedTakeHomeWebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonHistoryController : ControllerBase
{
    private readonly IPeopleQueryHandlerConsole queryHandler;
    private readonly ILogger<PersonHistoryController> logger;

    public PersonHistoryController(IModuleManagerService moduleManagerService, TardisContext tardisContext, IServiceProvider services, ILogger<PersonHistoryController> logger)
    {
        queryHandler = moduleManagerService.GetApi<IPeopleQueryHandlerConsole, PeopleQueryHandlerConsoleOptions>(o =>
        {
            o.Context = tardisContext;
            o.Services = services;
        });
        this.logger = logger;
    }

    [ProducesResponseType(typeof(IEnumerable<PersonHistoryResponseModel>), 200),
        ProducesResponseType(404)]
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        logger.LogInformation("I've been asked to get the historical changes person entity for id: {id}", id);

        List<PersonHistoryResponseModel> history = queryHandler.GetPersonHistory(id);

        if (!history.Any())
            return NotFound();
        else
            return Ok(history);
    }
}
