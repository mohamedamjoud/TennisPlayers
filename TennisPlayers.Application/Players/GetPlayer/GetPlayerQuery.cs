using MediatR;
using TennisPlayers.Application.Common;
using TennisPlayers.Application.Players.GetPlayers;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Players.GetPlayer;

public sealed record GetPlayerQuery(int Id) : IQuery<PlayerResponse>;