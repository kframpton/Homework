using Microsoft.AspNetCore.Mvc;
using StoriedTakeHomeWebApi.Interfaces.Commands;
using StoriedTakeHomeWebApi.RequestModels;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class BirthController : ControllerBase
{
    private readonly IPersonCommandHandler commandHandler;
    private readonly ILogger<PersonController> logger;

    public BirthController(IPersonCommandHandler commandHandler, ILogger<PersonController> logger)
    {
        this.commandHandler = commandHandler;
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
