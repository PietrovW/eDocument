using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManager.Worker.HostedService
{
    public class SendTaskHostedService : IHostedService
    {
        readonly IBusControl _bus;
        readonly ILogger _logger;
        public SendTaskHostedService(IBusControl bus, ILoggerFactory loggerFactory)
        {
            _bus = bus;
            _logger = loggerFactory.CreateLogger<SendTaskHostedService>();
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
