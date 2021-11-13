using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Context;
using eDocument.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using MediatR;
using System.Reflection;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.CommandHandler;
using System;
using Notifikation.Infrastructure.Extensions;
using System.Linq;

namespace Notifikation.Api
{
    using eDocument.Infrastructure.Repositories;
    using Newtonsoft.Json;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                     options.UseNpgsql(Configuration.GetConnectionString(typeof(NotifikationContext).Name),
                  h => h.MigrationsHistoryTable("MigrationsHitory", "Notifikation"))
             );
            ConfigureApi(services);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                  options.UseNpgsql(Configuration.GetConnectionString(typeof(NotifikationContext).Name),
                  h => h.MigrationsHistoryTable("MigrationsHitory", "Notifikation"))
             );
            ConfigureApi(services);
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            ConfigureApi(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString(typeof(NotifikationContext).Name),
                     h => h.MigrationsHistoryTable("MigrationsHitory", "Notifikation")));

            ConfigureApi(services);
        }
        private void ConfigureApi(IServiceCollection services)
        {
            services.RegisterServices(typeof(Startup).GetTypeInfo().Assembly, new Type[] { typeof(Api.Profiles.MappingProfile), typeof(Infrastructure.Profiles.NotifikationProfile) });
            services.AddOptions();
            services.RegisterServices(typeof(Startup).GetTypeInfo().Assembly, new Type[] { typeof(Api.Profiles.MappingProfile), typeof(Infrastructure.Profiles.NotifikationProfile) });
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddTransient<IReadRepository, Notifikation.Infrastructure.Repositories.ReadRepository>();
            services.AddTransient<IWriteIRepository, Notifikation.Infrastructure.Repositories.WriteIRepository>();
            services.RegisterSwaggerGenServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.RegisterSwaggerUIConfigure();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureTest(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app, isSeed: true);
        }

        private static void UpdateDatabase(IApplicationBuilder app, bool isSeed = false)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<NotifikationContext>())
                {

                    if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        context.Database.EnsureCreated();
                        if (!context.Database.GetPendingMigrations().Any())
                        {
                            context.Database.Migrate();
                        }
                    }
                    if (isSeed)
                    {
                        context.Seed();
                    }
                }
            }
        }
    }
}
