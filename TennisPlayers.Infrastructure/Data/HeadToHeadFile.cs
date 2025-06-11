using System.Text.Json.Serialization;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Infrastructure.Data;
public record HeadToHeadFile([property: JsonPropertyName("players")] List<PlayerRaw> Players);