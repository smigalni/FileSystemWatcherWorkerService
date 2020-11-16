using FileSystemWatcherWorkerService.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace FileSystemWatcherWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly FolderWatcherService _folderWatcherService;
        private readonly ILogger<Worker> _logger;
        private const string ApplicationName = "FileSystemWatcherDemo";

        public Worker(FolderWatcherService folderWatcherService,
            ILogger<Worker> logger)
        {
            _folderWatcherService = folderWatcherService;
            _logger = logger;
        }

        public override async Task StartAsync(
          CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Application {ApplicationName} started. ");

            await _folderWatcherService.StartWatch();
            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var waitIndefinitely = -1;
                await Task.Delay(waitIndefinitely, cancellationToken);
            }
        }

        public override async Task StopAsync(
          CancellationToken cancellationToken)
        {
            _logger.LogWarning($"Application {ApplicationName} stopped. ");
            await base.StopAsync(cancellationToken);
        }
    }
}