using System.Text.Json.Serialization;

namespace TennisPlayers.Infrastructure.Data;

public sealed record Country(
    [property: JsonPropertyName("picture")] string Picture,
    [property: JsonPropertyName("code")] string Code
);