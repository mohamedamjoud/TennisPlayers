using MediatR;
using TennisPlayers.Domain.Common.Error;

namespace TennisPlayers.Application.Common;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;