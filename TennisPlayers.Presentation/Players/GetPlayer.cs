using MediatR;
using TennisPlayers.Application.Players.GetPlayer;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Domain.Common.Error;
using TennisPlayers.Presentation.Abstractions;
using TennisPlayers.Presentation.Common.Results;

namespace TennisPlayers.Presentation.Players;

internal sealed class GetPlayer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("player/{id:int}", async (int id, ISender sender) =>
        {
            Result<PlayerResponse> result = await sender.Send(new GetPlayerQuery(id));
            
            return result.Match(Results.Ok, ApiResults.Problem);
            
        }).WithTags("Players");
    }
}