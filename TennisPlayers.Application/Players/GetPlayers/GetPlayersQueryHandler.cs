using TennisPlayers.Application.Common;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Players.GetPlayers;

public sealed class GetPlayersQueryHandler (IPlayerRepository playerRepository) 
    : IQueryHandler<GetPlayersQuery, IReadOnlyCollection<PlayerResponse>>
{
    public Task<Result<IReadOnlyCollection<PlayerResponse>>> Handle(
        GetPlayersQuery request, 
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<PlayerResponse> response = playerRepository.GetPlayers().SortPlayersBy(request.SortBy);
        
        return Task.FromResult<Result<IReadOnlyCollection<PlayerResponse>>>(response.ToList());
    }
}

public static class PlayerResponseExtensions
{
    public static IReadOnlyCollection<PlayerResponse> SortPlayersBy(this IReadOnlyCollection<PlayerResponse> players, PlayerSortBy sortBy) =>
        sortBy switch
        {
            PlayerSortBy.Rank => players.OrderBy(p=>p.Rank).ToList(),
            PlayerSortBy.None => players,
            _ => throw new ArgumentOutOfRangeException(nameof(sortBy), "Invalid sort option"),
        };
}