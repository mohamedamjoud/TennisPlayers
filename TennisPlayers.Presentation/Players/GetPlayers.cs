using MediatR;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Domain.Common.Error;
using TennisPlayers.Presentation.Abstractions;
using TennisPlayers.Presentation.Common.Results;

namespace TennisPlayers.Presentation.Players;

internal sealed class GetPlayers : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("players", async (ISender sender) =>
        {
            Result<IReadOnlyCollection<PlayerResponse>> result = await sender.Send(new GetPlayersQuery(SortBy: PlayerSortBy.Rank));

            return result.Match(Results.Ok, ApiResults.Problem);
        }).WithTags("Players");
    }
}