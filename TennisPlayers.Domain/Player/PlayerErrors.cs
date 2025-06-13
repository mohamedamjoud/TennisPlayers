using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Domain.Player;

public static class PlayerErrors
{
    public static Error NotFound(int playerId) => 
        Error.NotFound("Player.NotFound", $"The Player with identifier {playerId} was not found.");
}