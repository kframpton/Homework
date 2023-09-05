using Microsoft.AspNetCore.Mvc;
using StoriedTakeHomeWebApi.Interfaces.Queries;
using StoriedTakeHomeWebApi.ResponseModels;

namespace StoriedTakeHomeWebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class PersonHistoryController : ControllerBase
{
    private readonly IPersonQueryHandler queryHandler;
    private readonly ILogger<PersonHistoryController> logger;

    public PersonHistoryController(IPersonQueryHandler queryHandler, ILogger<PersonHistoryController> logger)
    {
        this.queryHandler = queryHandler;
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
