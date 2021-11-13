using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace eDocument.Infrastructure.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Assembly assemblie, Type[] profileAssemblyMarkerTypes)
        {
            services.AddMediatR(assemblie);
            services.AddAutoMapper(profileAssemblyMarkerTypes);
            return services;
        }
    }
}
