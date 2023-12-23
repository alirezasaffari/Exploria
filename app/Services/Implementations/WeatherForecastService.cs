using app.Helpers;
using app.Repos.Interfaces;
using app.Services.Interfaces;
using Didar.Wallet.App.Services.Implementations;
using Domain.Entities;
using Microsoft.Identity.Client;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace app.Services.Implementations;
public class WeatherForecastService : CommonService<WeatherForecast>, IWeatherForecastService
{
    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastService(ICommonRepo<WeatherForecast> repository, IUnitOfWork unitOfWork) : base(repository)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<string> GetForecast(CancellationToken cancellationToken)
    {
        //await Task.Delay(7000,cancellationToken);
        var sqlData = await _unitOfWork.WeatherForecast.GetFirstAsync(includes: null, orderBy: forecasts => forecasts.OrderByDescending(m => m.Id));
        return sqlData?.Data;
    }

    public async Task Add(CancellationToken cancellationToken,WeatherForecast entity)
    {
        //await Task.Delay(7000, cancellationToken);
        _unitOfWork.WeatherForecast.AddAsync(entity);
        await _unitOfWork.SaveChanges();
    }
}