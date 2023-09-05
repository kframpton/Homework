using Microsoft.AspNetCore.Mvc;
using StoriedTakeHomeWebApi.Interfaces.Commands;
using StoriedTakeHomeWebApi.RequestModels;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class DeathController : ControllerBase
{
    private readonly IPersonCommandHandler commandHandler;
    private readonly ILogger<PersonController> logger;

    public DeathController(IPersonCommandHandler commandHandler, ILogger<PersonController> logger)
    {
        this.commandHandler = commandHandler;
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
