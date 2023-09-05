using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StoriedTakeHomeWebApi.Controllers;
[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    private readonly ILogger<ErrorsController> logger;
    public ErrorsController(ILogger<ErrorsController> logger)
    {
        this.logger = logger;
    }

    [ProducesResponseType(typeof(ProblemDetails), 400),
        ProducesResponseType(typeof(ProblemDetails), 500),
        ProducesResponseType(typeof(ProblemDetails), 503)]
    [HttpGet]
    [HttpPut]
    [HttpPost]
    [HttpDelete]
    [Route("/errors")]
    public IActionResult HandleErrors()
    {
        try
        {
            string message = "Something went a little sideways...";
            string? type = null;
            HttpStatusCode responseCode = HttpStatusCode.InternalServerError;
            IExceptionHandlerFeature? context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (context != null)
            {
                logger.LogError(context.Error, "Unhandled error - No soup for you!");
                message = context.Error.Message;
                type = context.Error.GetType().Name;
                if (context.Error.InnerException != null)
                    message += $" - {context.Error.InnerException.Message}";

                responseCode = context.Error.GetType().Name switch
                {
                    "NullReferenceException" => HttpStatusCode.InternalServerError,
                    "WebException" => HttpStatusCode.BadRequest,
                    "ArgumentException" => HttpStatusCode.BadRequest,
                    "ArgumentNullException" => HttpStatusCode.BadRequest,
                    "ArgumentOutOfRangeException" => HttpStatusCode.BadRequest,
                    "AddPersonException" => HttpStatusCode.BadRequest,
                    "RecordBirthException" => HttpStatusCode.BadRequest,
                    "PersonException" => HttpStatusCode.BadRequest,
                    "OutdatedModuleException" => HttpStatusCode.InternalServerError,
                    "BadModuleException" => HttpStatusCode.InternalServerError,
                    "InvalidOperationException" => HttpStatusCode.InternalServerError,
                    _ => HttpStatusCode.ServiceUnavailable
                };
            }

            logger.LogError("Unhandled error {message}, {responseCode}", message, responseCode);
            return Problem(
                detail: message,
                statusCode: (int)responseCode,
                title: $"An error has occurred and was logged.  If contacting support, tell them it happened around {DateTime.Now:s}",
                type: type);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error handler noped right the out...");
            return Problem(detail: ex.Message, statusCode: 500);
        }
    }
}
