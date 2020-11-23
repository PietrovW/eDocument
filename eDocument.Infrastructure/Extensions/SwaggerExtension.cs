using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace eDocument.Infrastructure.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection RegisterSwaggerGenServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            return services;
        }

        public static IApplicationBuilder RegisterSwaggerUIConfigure(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            return app;
        }

    }
}
