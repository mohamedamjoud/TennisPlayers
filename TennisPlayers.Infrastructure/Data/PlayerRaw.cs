using System.Text.Json.Serialization;

namespace TennisPlayers.Infrastructure.Data;

public sealed record PlayerRaw(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("firstname")] string Firstname,
    [property: JsonPropertyName("lastname")] string Lastname,
    [property: JsonPropertyName("shortname")] string Shortname,
    [property: JsonPropertyName("sex")] string Sex,
    [property: JsonPropertyName("picture")] string Picture,
    [property: JsonPropertyName("country")] Country Country,
    [property: JsonPropertyName("data")] PlayerStats Data
);