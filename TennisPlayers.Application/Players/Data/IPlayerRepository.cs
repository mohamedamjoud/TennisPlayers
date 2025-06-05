using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Application.Players.Data;

public interface IPlayerRepository
{
    Task<IReadOnlyCollection<PlayerResponse>> GetPlayersAsync();
}