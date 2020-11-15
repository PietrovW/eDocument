using eDocument.Infrastructure.Options;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eDocument.Infrastructure.Extensions
{
    public static class QueueExtension
    {
        public static IServiceCollection RegisterQueueServices(this IServiceCollection services, HostBuilderContext context)
        {
            var busConfigOptions = new BusConfigOptions();
            services.AddMassTransit(provider =>
            {
                var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(busConfigOptions.HostName, busConfigOptions.VirtualHost,
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
