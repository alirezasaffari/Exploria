using Domain.Entities;

namespace app.Services.Interfaces;
public interface IWeatherForecastService : ICommonService<WeatherForecast>
{
    Task<string> GetForecast(CancellationToken cancellationToken);
    Task Add(CancellationToken cancellationToken, WeatherForecast entity);
}