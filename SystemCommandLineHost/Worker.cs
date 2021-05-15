using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SystemCommandLineHost
{
    class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;
        private readonly Arguments arguments;

        public Worker(ILogger<Worker> logger, Arguments arguments)
        {
            this.logger = logger;
            this.arguments = arguments;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                logger.LogInformation($"Configuration:{arguments.Configuration} Publish:{arguments.Publish}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
