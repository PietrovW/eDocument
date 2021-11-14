using FluentValidation;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eDocument.Infrastructure.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Assembly[] assemblie)
        {
            services.AddMediatR(assemblie);
            services.AddAutoMapper(assemblie);
            services.AddFluentValidation(assemblie);
            services.AddFluentValidationRulesToSwagger();

            return services;
        }
    }
}
