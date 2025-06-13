using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Infrastructure.Configuration;
using TennisPlayers.Infrastructure.Persistence.Helpers;
using TennisPlayers.Infrastructure.Persistence.Models;

namespace TennisPlayers.Infrastructure.Persistence.Repository;

public class PlayerRepository : IPlayerRepository
{
    
    private readonly IMemoryCache _cache;
    private readonly string _filePath;
    private readonly ILogger<PlayerRepository> _logger;

    public PlayerRepository(IOptions<DataFilesOptions> options, IMemoryCache cache, ILogger<PlayerRepository> logger)
    {
       _cache = cache;
       _filePath = options.Value.HeadToHead;
       _logger = logger;
    }

    public IReadOnlyCollection<PlayerResponse> GetPlayers()
    {
        return _cache.GetOrCreate("PlayersCache", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
            var headToHead = JsonFileHelper<HeadToHeadFile>.TryReadAsync(_filePath, _logger).GetAwaiter().GetResult();
            return headToHead?.Players?.Select(PlayerRaw.ToPlayerResponse).ToList() ?? [];
        });
    }    
    
    public PlayerResponse? GetPlayer(int playerId) => 
        GetPlayers().SingleOrDefault(p => p.Id == playerId);
  
}