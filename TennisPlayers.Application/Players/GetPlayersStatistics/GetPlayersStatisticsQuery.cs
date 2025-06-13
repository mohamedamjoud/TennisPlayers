using MediatR;
using TennisPlayers.Application.Common;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Players.GetPlayersStatistics;

public sealed record GetPlayersStatisticsQuery() : IQuery<PlayersStatisticsResponse>;