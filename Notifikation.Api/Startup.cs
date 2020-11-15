using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Context;
using eDocument.Infrastructure.Extensions;

namespace Notifikation.Api
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                    options.UseSqlite("Data Source=blogging.db")
                    );
            services.AddScoped<INotifikationWriteContext, NotifikationWriteContext>();
            services.AddScoped<INotifikationReadContext, NotifikationReadContext>();
            services.RegisterSwaggerGenServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.RegisterSwaggerUIConfigure();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
