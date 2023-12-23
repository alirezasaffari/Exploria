using app.Repos.Interfaces;
using infra.Contexts;

namespace app.Repos.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherForecastContext _context;

        public UnitOfWork(WeatherForecastContext context)
        {
            _context = context;
            WeatherForecast = new WeatherForecastRepo(_context);
        }

        public IWeatherForecastRepo WeatherForecast { get; set; }

        public async Task SaveChanges()
        {
            await using var dbContextTransaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbContextTransaction.RollbackAsync();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
