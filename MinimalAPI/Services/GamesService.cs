using MinimalAPI.ExceptionHandlers;
using MinimalAPI.Interfaces;
using MinimalAPI.Models;

namespace MinimalAPI.Services;

public class GamesService : IGamesService
{
    private readonly Games _games = new();

    public Game CreateGameObject(string name, string gamePublisher, decimal price)
    {
        var game = new Game
        {
            Name = name,
            GamePublisher = gamePublisher,
            Price = price,
        };
        game.SetID(GetNextId());

        _games.GameList.Add(game);
        return game;
    }

    public Games GetGames() => _games;

    public Game GetGameById(long ID)
    {
        var game = _games.GameList.FirstOrDefault(g => g.ID == ID);
        if (game == null)
            throw new GameNotFoundException();
        return game;
    }

    public Games GetGamesByPriceRange(decimal minPrice, decimal maxPrice)
    {
        if (minPrice < 0 || maxPrice < minPrice)
        {
            throw new InvalidInputException();
        }
        return new Games
        {
            GameList = _games
                .GameList.Where(game => game.Price >= minPrice && game.Price <= maxPrice)
                .ToList(),
        };
    }

    public long GetNextId()
    {
        if (_games.GameList.Any())
        {
            return _games.GameList.Max(game => game.ID) + 1;
        }
        return 1;
    }
}
