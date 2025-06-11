using MediatR;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Presentation.Abstractions;

namespace TennisPlayers.Presentation.Players;

internal sealed class GetPlayers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("players", async (ISender sender) =>
        {
            var players = await sender.Send(new GetPlayersQuery(SortBy: PlayerSortBy.Rank));

            return Results.Ok(players);
        }).WithTags("Players");
    }
}