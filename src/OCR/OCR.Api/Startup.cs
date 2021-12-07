using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tesseract;

namespace OCR.Api
{
    using eDocument.Infrastructure.Extensions;
    using eDocument.Infrastructure.Repositories;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureApi(services);
        }

        private void ConfigureApi(IServiceCollection services)
        {
            services.AddOptions();
            services.RegisterServices(new Assembly[] { typeof(Api.Profiles.OCRProfile).Assembly, typeof(Infrastructure.Profiles.OCRProfile).Assembly });
            services.AddControllers();
            services.AddScoped<IReadRepository, ReadRepository>();
            services.AddScoped<IWriteIRepository, WriteIRepository>();
            services.RegisterSwaggerGenServices();
            services.AddSingleton(new TesseractEngine(@"./tessdata", "eng", EngineMode.Default));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
