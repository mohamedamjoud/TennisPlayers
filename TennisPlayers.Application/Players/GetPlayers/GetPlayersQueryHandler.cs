using MediatR;
using TennisPlayers.Application.Players.Data;

namespace TennisPlayers.Application.Players.GetPlayers;

public sealed class GetPlayersQueryHandler (IPlayerRepository playerRepository) : IRequestHandler<GetPlayersQuery, IReadOnlyCollection<PlayerResponse>>
{
    public async Task<IReadOnlyCollection<PlayerResponse>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
    {
        
        var response = await playerRepository.GetPlayersAsync();
        return SortPlayersBy(request.SortBy, response);
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