using MediatR;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Application.Players.GetPlayer;

public class GetPlayerQueryHandler (IPlayerRepository playerRepository) : IRequestHandler<GetPlayerQuery, PlayerResponse>
{
    public Task<PlayerResponse> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        var response = playerRepository.GetPlayer(request.Id);
        return Task.FromResult(response);
    }
}