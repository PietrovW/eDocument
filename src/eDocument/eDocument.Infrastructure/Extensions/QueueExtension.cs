using eDocument.Infrastructure.Options;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eDocument.Infrastructure.Extensions
{
    public static class QueueExtension
    {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services)
        {
            var busConfigOptions = new BusConfigOptions();
            busConfigOptions.UserName = "guest";
            busConfigOptions.Password= "guest";
            busConfigOptions.HostName = "localhost";
            services.AddMassTransit(provider =>
            {
                var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(busConfigOptions.HostName,
                    h => {
                        h.Username(busConfigOptions.UserName);
                        h.Password(busConfigOptions.Password);
                    });
                });

                services.AddSingleton<IPublishEndpoint>(bus);
                services.AddSingleton<ISendEndpointProvider>(bus);
                services.AddSingleton<IBus>(bus);

                bus.Start();
            });
            return services;
        }
    }
}
