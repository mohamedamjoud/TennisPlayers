using MediatR;
using TennisPlayers.Application.Players.GetPlayersStatistics;
using TennisPlayers.Presentation.Abstractions;

namespace TennisPlayers.Presentation.Players;

public class GetPlayersStatistics: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/statistics", async (ISender sender) =>
        {
            var statistics = await sender.Send(new GetPlayersStatisticsQuery());
            
            return Results.Ok(statistics);
        }).WithTags("Statistics");
    }
}