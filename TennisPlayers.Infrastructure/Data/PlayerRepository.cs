using Microsoft.Extensions.Configuration;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Infrastructure.Data;

public class PlayerRepository : IPlayerRepository
{
    private readonly string _filePath;

    public PlayerRepository(IConfiguration configuration)
    {
        _filePath = configuration["DataFiles:HeadToHead"]
                    ?? throw new InvalidOperationException("Missing configuration for HeadToHead file path.");
    }
    public async Task<IReadOnlyCollection<PlayerResponse>> GetPlayersAsync()
    {
        
        if (!File.Exists(_filePath))
        {
            throw new ApplicationException("The file 'HeadToHead.json' was not found.");
        }
        
        var headToHeadPlayers = await JsonFileHelper<HeadToHeadFile>.ReadAsync(_filePath);
        return headToHeadPlayers?.Players?.Select(HeadToHeadFile.ToPlayerResponse).ToList() ?? [];
    }
}