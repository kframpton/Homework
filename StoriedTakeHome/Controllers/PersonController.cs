using Microsoft.AspNetCore.Mvc;
using StoriedTakeHomeWebApi.Interfaces.Commands;
using StoriedTakeHomeWebApi.Interfaces.Queries;
using StoriedTakeHomeWebApi.RequestModels;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Controllers;
[Route("[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonCommandHandler commandHandler;
    private readonly IPersonQueryHandler queryHandler;
    private readonly ILogger<PersonController> logger;

    public PersonController(IPersonCommandHandler commandHandler, IPersonQueryHandler queryHandler, ILogger<PersonController> logger)
    {
        this.commandHandler = commandHandler;
        this.queryHandler = queryHandler;
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

        return Created($"http{(Request.IsHttps ? "s": "")}://{Request.Host}{Request.Path}", person);
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
