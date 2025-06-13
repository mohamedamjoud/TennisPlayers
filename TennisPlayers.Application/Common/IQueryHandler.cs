using MediatR;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Common;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;