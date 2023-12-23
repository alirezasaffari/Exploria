using app.Repos.Interfaces;
using Domain.Entities;
using infra.Contexts;

namespace app.Repos.Implementations;

public class WeatherForecastRepo : CommonRepo<WeatherForecast>,IWeatherForecastRepo
{
    public WeatherForecastRepo(WeatherForecastContext dbContext) : base(dbContext) { }
}