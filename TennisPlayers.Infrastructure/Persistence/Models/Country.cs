using System.Text.Json.Serialization;

namespace TennisPlayers.Infrastructure.Persistence.Models;

public sealed record Country(
    [property: JsonPropertyName("picture")] string Picture,
    [property: JsonPropertyName("code")] string Code
);