using System;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tesseract;

namespace OCR.Api
{
    using eDocument.Infrastructure.Extensions;
    using eDocument.Infrastructure.Repositories;
    using OCR.Infrastructure.Command;
    using OCR.Infrastructure.CommandHandler;
    using OCR.Infrastructure.DTO;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureApi(services);
            
        }

        private void ConfigureApi(IServiceCollection services)
        {
            services.AddOptions();
            services.RegisterServices(typeof(Startup).GetTypeInfo().Assembly, new Type[] { typeof(Api.Profiles.OCRProfile), typeof(Infrastructure.Profiles.OCRProfile) });
            services.AddControllers();
            services.AddScoped<IReadRepository, ReadRepository>();
            services.AddScoped<IWriteIRepository, WriteIRepository>();
            services.RegisterSwaggerGenServices();
            services.AddSingleton(new TesseractEngine(@"./tessdata", "eng", EngineMode.Default));
            services.AddScoped<IRequestHandler<CreateDocumentCommand, DocumentDTO>, CreateDocumentCommandHandler>();
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
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
