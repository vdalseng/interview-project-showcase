using Microsoft.AspNetCore.Diagnostics;

namespace MinimalAPI.ExceptionHandlers;

public class GameNotFoundExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is GameNotFoundException)
        {
            return ValueTask.FromResult(true);
        }
        return ValueTask.FromResult(false);
    }
}

public class InvalidInputExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is InvalidInputException)
        {
            return ValueTask.FromResult(true);
        }
        return ValueTask.FromResult(false);
    }
}
