using System.Text.Json.Serialization;
using TennisPlayers.Application.Players.GetPlayers;

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
)
{
    public static PlayerResponse ToPlayerResponse(PlayerRaw raw) =>
        new(
            raw.Id,
            raw.Firstname,
            raw.Lastname,
            raw.Shortname,
            raw.Country.Code,
            raw.Data?.Rank ?? 0,
            raw.Data?.Last,
            raw.Data?.Weight ?? 0,
            raw.Data?.Height ?? 0
        );
};