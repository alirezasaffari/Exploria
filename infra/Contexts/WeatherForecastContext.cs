using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infra.Contexts;
public class WeatherForecastContext : DbContext
{
    public WeatherForecastContext(DbContextOptions<WeatherForecastContext> context) : base(context) { }

    public DbSet<WeatherForecast> WeatherForecast { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
    }
}