using FluentValidation;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace eDocument.Infrastructure.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Assembly[] assemblie)
        {
            services.AddMediatR(assemblie);
            services.AddAutoMapper(assemblie);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddValidatorsFromAssemblies(assemblie);
            //services.AddFluentValidation(assemblie);
            //services.AddFluentValidation(fv => fv.ValidatorFactory = new MyValidatorFactory())
            services.AddFluentValidationRulesToSwagger();

            return services;
        }
    }
}
