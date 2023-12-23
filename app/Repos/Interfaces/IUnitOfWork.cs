namespace app.Repos.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IWeatherForecastRepo WeatherForecast { get; set; }
        Task SaveChanges();
    }
}
