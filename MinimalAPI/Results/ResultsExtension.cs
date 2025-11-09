using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI.Results;

public static class ResultExtensions
{
    public static ActionResult ToActionResult(this Result result) =>
        result.Status switch
        {
            Status.Ok => new OkResult(),
            Status.Created => new CreatedResult(string.Empty, result.Value),
            Status.NoContent => new NoContentResult(),
            Status.NotModified => new StatusCodeResult(304),
            Status.BadRequest => new BadRequestObjectResult(result.Errors),
            Status.Invalid => new BadRequestObjectResult(result.Errors),
            Status.NotFound => new NotFoundObjectResult(result.Errors),
            Status.Error => new ObjectResult(result.Errors) { StatusCode = 500 },
            Status.Unavailable => new ObjectResult(result.Errors) { StatusCode = 503 },
            _ => new ObjectResult(result.Errors) { StatusCode = 500 },
        };

    public static ActionResult ToActionResult<T>(this Result<T> result) =>
        result.Status switch
        {
            Status.Ok => new OkObjectResult(result.Value),
            Status.Created => new CreatedResult(string.Empty, result.Value),
            Status.NoContent => new NoContentResult(),
            Status.NotModified => new StatusCodeResult(304),
            Status.BadRequest => new BadRequestObjectResult(result.Errors),
            Status.Invalid => new BadRequestObjectResult(result.Errors),
            Status.NotFound => new NotFoundObjectResult(result.Errors),
            Status.Error => new ObjectResult(result.Errors) { StatusCode = 500 },
            Status.Unavailable => new ObjectResult(result.Errors) { StatusCode = 503 },
            _ => new ObjectResult(result.Errors) { StatusCode = 500 },
        };
}
