using MediatR;
using TennisPlayers.Application.Common;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Domain.Common.Error;
using TennisPlayers.Domain.Player;

namespace TennisPlayers.Application.Players.GetPlayer;

internal sealed class GetPlayerQueryHandler (IPlayerRepository playerRepository) 
    : IQueryHandler<GetPlayerQuery, PlayerResponse>
{
    public Task<Result<PlayerResponse>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
    {
        PlayerResponse? player = playerRepository.GetPlayer(request.Id);
        
        if (player is null)
        {
            return Task.FromResult(Result.Failure<PlayerResponse>(PlayerErrors.NotFound(request.Id))); ;
        }
        
        return Task.FromResult<Result<PlayerResponse>>(player);
    }
}