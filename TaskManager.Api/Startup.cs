using System;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.SQLite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TaskManager.Api
{
    using eDocument.Infrastructure.Extensions;
    using TaskManager.Infrastructure.Activator;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHangfire(opts => opts.UseMemoryStorage());
        }
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddControllers();
            services.RegisterQueueServices();
            services.AddHangfire(opts => opts.UseSQLiteStorage(Guid.NewGuid().ToString()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            GlobalConfiguration.Configuration.UseActivator(new ServiceProviderActivator(serviceProvider));
            app.UseHangfireServer();
            app.UseHangfireDashboard();
        }
    }
}
