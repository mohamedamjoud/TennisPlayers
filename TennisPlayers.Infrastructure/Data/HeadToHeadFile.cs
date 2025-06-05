using System.Text.Json.Serialization;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Infrastructure.Data;

public record HeadToHeadFile([property: JsonPropertyName("players")]List<PlayerRaw> Players)
{
    public static PlayerResponse ToPlayerResponse(PlayerRaw raw) =>
        new(
            raw.Id,
            raw.Firstname,
            raw.Lastname,
            raw.Shortname,
            raw.Data?.Rank ?? 0,
            raw.Data?.Points ?? 0
        );};