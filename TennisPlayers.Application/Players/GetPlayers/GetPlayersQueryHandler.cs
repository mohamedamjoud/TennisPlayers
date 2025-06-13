using MediatR;
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
        IReadOnlyCollection<PlayerResponse> response = playerRepository.GetPlayers();
        
        return Task.FromResult<Result<IReadOnlyCollection<PlayerResponse>>>(response.ToList());
    }

    private IReadOnlyCollection<PlayerResponse> SortPlayersBy(PlayerSortBy sortBy,
         IReadOnlyCollection<PlayerResponse> players) =>
        sortBy switch
        {
            PlayerSortBy.Rank => players.OrderBy(p=>p.Rank).ToList(),
            PlayerSortBy.None => players,
            _ => throw new ArgumentOutOfRangeException(nameof(sortBy), "Invalid sort option"),
        };
}