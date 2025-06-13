using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TennisPlayers.Application.Players.Data;
using TennisPlayers.Infrastructure.Data;

namespace TennisPlayers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DataFilesOptions>(configuration.GetSection("DataFiles"));
        services.AddMemoryCache();
        services.AddSingleton<IPlayerRepository, PlayerRepository>();
        return services;
    }
            
    
}