using Microsoft.Extensions.DependencyInjection;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Infrastructure.Data;

namespace TennisPlayers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
            services.AddSingleton<IPlayerRepository, PlayerRepository>();
    
}