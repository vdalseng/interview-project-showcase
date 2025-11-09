namespace MinimalAPI.Middleware;

public class CustomMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        // Logic to execute before the next middleware
        Console.WriteLine($"Request: {context.Request.Path}");

        await _next(context); // Invoke the next middleware in the pipeline

        // Logic to execute after the next middleware
        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}
