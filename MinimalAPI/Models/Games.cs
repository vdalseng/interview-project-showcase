using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models;

public record Game
{
    public long ID { get; private set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public string? ReleaseDate { get; set; }
    public string? GameStudio { get; set; }
    public string? GamePublisher { get; set; }

    public void SetID(long id)
    {
        ID = id;
    }
}

public record CreateGameRequest(
    [Required]
    [StringLength(
        100,
        MinimumLength = 1,
        ErrorMessage = "Name must be between 1 and 100 characters"
    )]
        string Name,
    [Required]
    [CustomValidation(typeof(CreateGameRequest), nameof(CreateGameRequest.ValidatePrice))]
        decimal Price,
    [DataType(DataType.Date)] DateOnly? ReleaseDate,
    [StringLength(100)] string? GameStudio,
    [Required] [StringLength(100, MinimumLength = 1)] string GamePublisher
)
{
    public static ValidationResult? ValidatePrice(decimal price)
    {
        if (price >= 0)
            return ValidationResult.Success;

        return new ValidationResult("Price cannot be negative");
    }
};

public record GameResponse(
    [property: Required] long ID,
    [property: Required] string Name,
    [property: Required] decimal Price,
    [property: DataType(DataType.Date)] DateOnly ReleaseDate,
    [property: DataType(DataType.Text)] string? GameStudio,
    [property: Required] string GamePublisher
);

public class Games
{
    public List<Game> GameList { get; set; } = [];
}
