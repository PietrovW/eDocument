using Hangfire;
using System;

namespace TaskManager.Infrastructure.Activator
{
    public class ServiceProviderActivator : JobActivator
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceProviderActivator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override object ActivateJob(Type type)
        {
            return _serviceProvider.GetService(type);
        }
    }
}
