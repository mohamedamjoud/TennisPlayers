using Microsoft.Extensions.DependencyInjection;
using TennisPlayers.Application.Behaviors;

namespace TennisPlayers.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
        });
        return services;
    }
}