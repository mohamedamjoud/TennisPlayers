using MediatR;
using TennisPlayers.Application.Players.GetPlayersStatistics;
using TennisPlayers.Domain.Common.Error;
using TennisPlayers.Presentation.Abstractions;
using TennisPlayers.Presentation.Common.Results;

namespace TennisPlayers.Presentation.Players;

public class GetPlayersStatistics: IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/players/statistics", async (ISender sender) =>
        {
            Result<PlayersStatisticsResponse> result = await sender.Send(new GetPlayersStatisticsQuery());
            
            return result.Match(Results.Ok, ApiResults.Problem); 
            
        }).WithTags("Statistics");
    }
}