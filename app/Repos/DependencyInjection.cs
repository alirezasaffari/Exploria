using app.Repos.Implementations;
using app.Repos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace app.Repos;
public static class DependencyInjection
{
    public static IServiceCollection AddRepos(this IServiceCollection services)
    {
        services.AddCommonRepo();
        services.AddWeatherForecastRepo();
        services.AddUnitOfWork();
        return services;
    }

    public static void AddCommonRepo(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICommonRepo<>), typeof(CommonRepo<>));
    }
    public static void AddWeatherForecastRepo(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastRepo, WeatherForecastRepo>();
    }

    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        return services;
    }


}