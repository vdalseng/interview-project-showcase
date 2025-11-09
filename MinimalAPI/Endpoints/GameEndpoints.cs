namespace MinimalAPI.Endpoints;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;
using MinimalAPI.Results;

public static class GameEndpoints
{
    private static readonly string[] _tags = ["Games"];

    public static WebApplication AddGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithTags(_tags);

        group
            .MapGet("/", GetAllGames)
            .WithName("GetAllGamesInformation")
            .WithSummary("Get all games information")
            .WithDescription("Get all games information")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status503ServiceUnavailable);

        group
            .MapGet("/{id:int}", GetGameById)
            .WithName("GetGameByID")
            .WithSummary("Get game information by ID")
            .WithDescription("Get game information by ID")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status503ServiceUnavailable);

        group
            .MapGet("/price-range", GetGamesByPriceRange)
            .WithName("GetGameInPriceRange")
            .WithSummary("Get game within price-range")
            .WithDescription("Get game within price-range")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status503ServiceUnavailable);

        group
            .MapPost("/", CreateGame)
            .WithName("CreateGame")
            .WithSummary("Create new game object")
            .WithDescription("Create new game object")
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesProblem(StatusCodes.Status503ServiceUnavailable);
        return app;
    }

    private static IResult GetAllGames(IGamesService service)
    {
        var games = service.GetGames();

        return games.GameList.Count > 0
            ? Result<Games>.Success(games)
            : Result<Games>.Failure("Games not found");
    }

    // private static async Task<Results<Ok<Games>, ProblemHttpResult>> GetAllGames(IGamesService service)
    // {
    //     var games = service.GetGames();
    //     if (games.GameList.Any())
    //         return TypedResults.Ok(games);

    //     var problemDetails = new ProblemDetails
    //     {
    //         Status = StatusCodes.Status404NotFound,
    //         Title = "Not found",
    //         Detail = "Games not found"
    //     };
    //     return TypedResults.Problem(problemDetails);
    // }

    private static async Task<Results<Ok<Game>, ProblemHttpResult>> GetGameById(
        int id,
        IGamesService service
    )
    {
        var game = service.GetGameById(id);
        if (game.ID == id)
            return TypedResults.Ok(game);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Not Found",
            Detail = "Game not found",
        };
        return TypedResults.Problem(problemDetails);
    }

    private static async Task<Results<Ok<Games>, ProblemHttpResult>> GetGamesByPriceRange(
        decimal minPrice,
        decimal maxPrice,
        IGamesService service
    )
    {
        var games = service.GetGamesByPriceRange(minPrice, maxPrice);
        if (games.GameList.Any())
            return TypedResults.Ok(games);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Not found",
            Detail = "Games not found",
        };
        return TypedResults.Problem(problemDetails);
    }

    private static async Task<Results<Ok<Game>, ProblemHttpResult>> CreateGame(
        string name,
        string gamePublisher,
        decimal price,
        IGamesService service
    )
    {
        if (
            !string.IsNullOrWhiteSpace(name)
            && !string.IsNullOrWhiteSpace(gamePublisher)
            && price >= 0
        )
        {
            var game = service.CreateGameObject(name, gamePublisher, price);
            return TypedResults.Ok(game);
        }

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Invalid Input",
            Detail = "Name and publisher cannot be empty, and price cannot be negative",
        };

        return TypedResults.Problem(problemDetails);
    }
}
