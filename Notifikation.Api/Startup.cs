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
using Microsoft.EntityFrameworkCore.Migrations;
using Notifikation.Infrastructure.MigrationsSqlGenerators;

namespace Notifikation.Api
{
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
                    options.UseSqlite(Configuration.GetConnectionString("NotifikationContext"), x => x.MigrationsAssembly("SqliteMigrations"))
                    );
            ConfigureApi(services);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
             services.AddDbContext<NotifikationContext>(options =>
                   options.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres", x => x.MigrationsAssembly("PostgreSQLMigrations"))
                   .ReplaceService<IMigrationsSqlGenerator, PostgreSQLMigrationsSqlGenerator>()
              .EnableDetailedErrors(),ServiceLifetime.Transient
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
                    options.UseSqlite("Data Source=Notifikation.db")
                    );
            ConfigureApi(services);
        }
        private void ConfigureApi(IServiceCollection services)
        {
            services.AddOptions();
            services.RegisterServices(typeof(Startup).GetTypeInfo().Assembly);
            services.AddControllers();
            services.AddScoped<INotifikationWriteContext, NotifikationWriteContext>();
            services.AddScoped<INotifikationReadContext, NotifikationReadContext>();
            services.RegisterSwaggerGenServices();

            services.AddScoped<IRequestHandler<CreateNotifikationCommand, NotifikatItemDTO>, CreateNotifikationCommandHandler>();
        }

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
                endpoints.MapControllers();
            });
        }
    }
}
