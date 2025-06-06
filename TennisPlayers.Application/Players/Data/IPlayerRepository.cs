using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Application.Players.Data;

public interface IPlayerRepository
{
    IReadOnlyCollection<PlayerResponse> GetPlayers();
    PlayerResponse GetPlayer(int playerId);
}