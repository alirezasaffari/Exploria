using app.Helpers;
using app.Services.Interfaces;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using Request = app.Helpers.Request;

namespace Exploria_Task.Controllers;
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IUnitOfService _unitOfService;
    private const string BaseUrl = "https://api.open-meteo.com";
    private readonly Request _request;


    public WeatherForecastController(IUnitOfService unitOfService)
    {
        _request = new Request(BaseUrl);
        _unitOfService = unitOfService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get()
    {
        var cancellationTokenSource = new CancellationTokenSource(4000);
        cancellationTokenSource.Token.ThrowIfCancellationRequested();
        string? data = null;
        try
        {
            data = await _unitOfService.WeatherForecast.GetForecast(cancellationTokenSource.Token);
            data = await _request.Execute("/v1/forecast?latitude=52.52&longitude=13.41&hourly=temperature_2m,relativehumidity_2m,windspeed_10m",cancellationToken:cancellationTokenSource.Token);
            await _unitOfService.WeatherForecast.Add(cancellationTokenSource.Token,new WeatherForecast {Data = data});

            return Ok(data);
        }
        catch (Exception )
        {
            return Ok(data);
        }
    }
}