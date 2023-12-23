using infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infra;
public static class ServiceRegistration
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext(configuration);
        return services;
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<WeatherForecastContext>(options => options.UseSqlServer(configuration.GetConnectionString("WeatherForecastConnectionString")));
    }
}