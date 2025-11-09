using MinimalAPI.Endpoints;
using MinimalAPI.ExceptionHandlers;
using MinimalAPI.Interfaces;
using MinimalAPI.Middleware;
using MinimalAPI.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddExceptionHandler<GameNotFoundExceptionHandler>()
    .AddExceptionHandler<InvalidInputExceptionHandler>()
    .AddOpenApi()
    .AddSingleton<IGamesService, GamesService>()
    .AddValidation()
    .AddHealthChecks();

var app = builder.Build();

app.Use(
        async (context, next) =>
        {
            await next.Invoke();
        }
    )
    .Use(
        async (context, next) =>
        {
            await next.Invoke();
        }
    );

app.UseMiddleware<CustomMiddleware>();

app.UseExceptionHandler("/Error");

app.MapOpenApi();

app.MapHealthChecks("/health");

app.AddGamesEndpoints();

app.MapScalarApiReference(options =>
{
    options.Title = "Games API";
    options.Theme = ScalarTheme.Moon;
});

await app.RunAsync();
