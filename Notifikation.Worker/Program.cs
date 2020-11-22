using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Context;
using Microsoft.Extensions.Logging;
using eDocument.Infrastructure.Extensions;
using Notifikation.Worker.BackgroundServices;

namespace Notifikation.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<NotifikationContext>(options =>
                    options.UseSqlite("Data Source=blogging.db")
                    );
                    services.AddScoped<INotifikationWriteContext, NotifikationWriteContext>();
                    services.AddScoped<INotifikationReadContext, NotifikationReadContext>();
                    services.RegisterQueueServices();
                    services.AddHostedService<SendMessageHostedService>();
                    }).ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                });
    }
}
