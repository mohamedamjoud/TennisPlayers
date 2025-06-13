using MediatR;
using TennisPlayers.Application.Common;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Players.GetPlayers;

public sealed record GetPlayersQuery (PlayerSortBy SortBy = PlayerSortBy.None) : IQuery<IReadOnlyCollection<PlayerResponse>>;