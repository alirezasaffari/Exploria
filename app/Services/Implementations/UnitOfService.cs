using app.Repos.Interfaces;
using app.Services.Implementations;
using app.Services.Interfaces;
using Domain.Entities;

namespace Didar.Wallet.App.Services.Implementations
{
    public class UnitOfService : IUnitOfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfService(IUnitOfWork unitOfWork, ICommonRepo<WeatherForecast> weatherForecastRepo)
        {
            _unitOfWork = unitOfWork;
            WeatherForecast = new WeatherForecastService(weatherForecastRepo, unitOfWork);
        }

        public IWeatherForecastService WeatherForecast { get; set; }

        public async Task SaveChanges()
        {
            await _unitOfWork.SaveChanges();
        }
    }
}
