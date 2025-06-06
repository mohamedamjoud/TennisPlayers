using System.Text.Json.Serialization;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Infrastructure.Data;
//Todo : think about, if i use this in the Domain
public record HeadToHeadFile([property: JsonPropertyName("players")] List<PlayerRaw> Players);