using app.Services.Implementations;
using app.Services.Interfaces;
using Didar.Wallet.App.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace app.Services;
public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddWeatherForecastService();
        services.AddUnitOfService();

        return services;
    }

    public static void AddWeatherForecastService(this IServiceCollection services)
    {
        services.AddScoped<IWeatherForecastService, WeatherForecastService>();
    }

  
    public static IServiceCollection AddUnitOfService(this IServiceCollection services)
    {
        services.AddTransient<IUnitOfService, UnitOfService>();
        return services;
    }
}