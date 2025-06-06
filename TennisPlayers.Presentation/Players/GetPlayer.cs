using MediatR;
using TennisPlayers.Application.Players.GetPlayer;
using TennisPlayers.Presentation.Abstractions;

namespace TennisPlayers.Presentation.Players;

internal sealed class GetPlayer : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("player/{id}", async (int id, ISender sender) =>
        {
            var player = await sender.Send(new GetPlayerQuery(id));
            
            return player is not null 
                ? Results.Ok(player) 
                : Results.NotFound();
        }).WithTags("Players");
    }
}