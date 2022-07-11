using WorkerService_BackgroundService_Demo;
using WorkerService_BackgroundService_Demo.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(opt => {
        opt.ServiceName = "WorkerService_Demo";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IFileToDatabaseFakeService, FileToDatabaseFakeService>();
    })    
    .Build();

await host.RunAsync();
