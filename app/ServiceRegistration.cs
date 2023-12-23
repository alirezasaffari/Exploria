using app.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace app;
public static class ServiceRegistration
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddRepos();
        return services;
    }
}