using MediatR;

namespace TennisPlayers.Application.Players.GetPlayers;

public sealed record GetPlayersQuery (PlayerSortBy SortBy = PlayerSortBy.None) : IRequest<IReadOnlyCollection<PlayerResponse>>;