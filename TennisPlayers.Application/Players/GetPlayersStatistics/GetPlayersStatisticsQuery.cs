using MediatR;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Application.Players.GetPlayersStatistics;

public sealed record GetPlayersStatisticsQuery() : IRequest<PlayersStatisticsResponse>;