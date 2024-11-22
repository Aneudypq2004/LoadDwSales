using LoadDWSales.Data.Interfaces;

namespace LoadDwSales.WorkerService
{
    public class Worker(ILogger<Worker> logger,
                  IServiceScopeFactory scopeFactory) : BackgroundService
    {
        private readonly ILogger<Worker> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }

                using (var scope = scopeFactory.CreateScope())
                {
                    var dataService = scope.ServiceProvider.GetRequiredService<IDataServiceDwSales>();
                    var result = await dataService.LoadDHW();
                }
                await Task.Delay(100000, stoppingToken);
            }
        }
    }
}
