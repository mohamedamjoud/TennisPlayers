using Microsoft.Extensions.Configuration;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Infrastructure.Data;

public class PlayerRepository : IPlayerRepository
{
    private readonly IReadOnlyCollection<PlayerResponse> _players;
    
    public PlayerRepository(IConfiguration configuration)
    {
        var filePath = configuration["DataFiles:HeadToHead"]
                    ?? throw new InvalidOperationException("Missing configuration for HeadToHead file path.");
        
        var headToHead = JsonFileHelper<HeadToHeadFile>.ReadAsync(filePath).GetAwaiter().GetResult();
        _players = headToHead?.Players?.Select(PlayerRaw.ToPlayerResponse).ToList() ?? [];
    }

    public IReadOnlyCollection<PlayerResponse> GetPlayers() => _players;
    
    public PlayerResponse? GetPlayer(int playerId) => 
        _players.SingleOrDefault(p => p.Id == playerId);
  
}