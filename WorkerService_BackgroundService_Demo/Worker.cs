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
                _logger.LogInformation("Volcando fichero a bb¡ase de datos a las : {time}", DateTimeOffset.Now);
                await fileToDatabaseFakeService.Volcarfichero();
                //Esperamos una hora antes de continuar.
                //await Task.Delay(3600000, stoppingToken);                
                await Task.Delay(5000, stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"el servicio se ha detenido a las {DateTime.Now}.");
            await base.StopAsync(stoppingToken);
        }

    }
}