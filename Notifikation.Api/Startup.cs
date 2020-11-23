using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Notifikation.Infrastructure.Context;
using eDocument.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Migrations;
using AutoMapper;
using MediatR;
using System.Reflection;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.CommandHandler;

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
                    options.UseSqlite(Configuration.GetConnectionString("NotifikationContext"))
                    );
            ConfigureApi(services);
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("NotifikationContext") ,x => x.MigrationsAssembly("Notifikation.Api.Migrations"))
                    /// .ReplaceService<IMigrationsSqlGenerator, SqliteMigrationsSqlGenerator>()
                    .EnableDetailedErrors(),ServiceLifetime.Transient
                    );
            ConfigureApi(services);
        }

        public void ConfigureTestServices(IServiceCollection services)
        {
            services.AddDbContext<NotifikationContext>(options =>
                    options.UseInMemoryDatabase(Configuration.GetConnectionString("NotifikationContext"))
                    );
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
