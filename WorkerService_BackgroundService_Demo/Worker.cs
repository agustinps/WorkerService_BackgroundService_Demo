using WorkerService_BackgroundService_Demo.Services;

namespace WorkerService_BackgroundService_Demo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileToDatabaseFakeService fileToDatabaseFakeService;

        public Worker(ILogger<Worker> logger, IFileToDatabaseFakeService fileToDatabaseFakeService)
        {
            _logger = logger;
            this.fileToDatabaseFakeService = fileToDatabaseFakeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await fileToDatabaseFakeService.Volcarfichero();
                //Esperamos una hora antes de continuar.
                await Task.Delay(3600000, stoppingToken);                
            }
        }
        
    }
}