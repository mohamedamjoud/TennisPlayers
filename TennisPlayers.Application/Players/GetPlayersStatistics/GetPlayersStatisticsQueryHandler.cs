using MediatR;
using TennisPlayers.Application.Common;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Domain;
using TennisPlayers.Domain.Common.Error;
using TennisPlayers.Domain.Player;

namespace TennisPlayers.Application.Players.GetPlayersStatistics;

public sealed class GetPlayersStatisticsQueryHandler (IPlayerRepository playerRepository) 
    : IQueryHandler<GetPlayersStatisticsQuery, PlayersStatisticsResponse>
{
    public Task<Result<PlayersStatisticsResponse>> Handle(GetPlayersStatisticsQuery request, CancellationToken cancellationToken)
    {
        var players = playerRepository.GetPlayers();

        var countryWithHighestWinRatio = players
            .GroupBy(p=>p.CountryCode)
            .Select(g => new
            {
                winRatio = g.Average(p => p.LastMatches.Average()),
                Country = g.Key
            }).OrderByDescending(p => p.winRatio)
            .FirstOrDefault()
            ?.Country;

        var averageBmi = players.Average(p => PlayerStatisticsCalculator.CalculateBmi(p.Weight, p.Height));
        
        var orderedHeights = players.Select(p => p.Height).OrderBy(h => h).ToList();
        var medianHeight = PlayerStatisticsCalculator.CalculateMedianHeight(orderedHeights);
        
        return Task.FromResult<Result<PlayersStatisticsResponse>>(new PlayersStatisticsResponse(countryWithHighestWinRatio, averageBmi, medianHeight));
    }
}