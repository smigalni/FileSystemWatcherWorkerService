using AutoMapper;
using FileSystemWatcherWorkerService;
using FileSystemWatcherWorkerService.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

CreateHostBuilder(args).Build().Run();


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddTransient<FolderWatcherService>();
            services.AddTransient<ConfigurationManagerService>();

            services.AddAutoMapper(typeof(Worker));

            services.AddHostedService<Worker>();
        });
    

