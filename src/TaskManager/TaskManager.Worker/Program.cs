using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Worker.HostedService;

namespace TaskManager.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostingContext, config) =>
             {
                 config.AddEnvironmentVariables();
             })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<SendTaskHostedService>();
                });
    }
}
