using MediatR;
using TennisPlayers.Application.Players.GetPlayers;

namespace TennisPlayers.Application.Players.GetPlayer;

public sealed record GetPlayerQuery(int Id) : IRequest<PlayerResponse?>;