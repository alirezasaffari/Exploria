namespace app.Services.Interfaces
{
    public interface IUnitOfService
    {
        IWeatherForecastService WeatherForecast { get; }
        Task SaveChanges();
    }
}
