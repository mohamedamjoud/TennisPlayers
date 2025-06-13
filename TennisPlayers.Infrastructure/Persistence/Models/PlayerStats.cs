using System.Text.Json.Serialization;

namespace TennisPlayers.Infrastructure.Persistence.Models;

public sealed record PlayerStats(
    [property: JsonPropertyName("rank")] int Rank,
    [property: JsonPropertyName("points")] int Points,
    [property: JsonPropertyName("weight")] int Weight,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("age")] int Age,
    [property: JsonPropertyName("last")] List<int> Last
);