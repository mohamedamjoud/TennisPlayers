using System.Text.Json.Serialization;

namespace TennisPlayers.Infrastructure.Persistence.Models;
public record HeadToHeadFile([property: JsonPropertyName("players")] List<PlayerRaw> Players);