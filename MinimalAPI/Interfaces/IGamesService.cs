using MinimalAPI.Models;

namespace MinimalAPI.Interfaces;

public interface IGamesService
{
    long GetNextId();

    Game CreateGameObject(string name, string gamePublisher, decimal price);
    Games GetGames();
    Game GetGameById(long ID);
    Games GetGamesByPriceRange(decimal minPrice, decimal maxPrice);
}
