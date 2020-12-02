using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using eDocument.Infrastructure.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OCR.Infrastructure.Command;
using OCR.Infrastructure.CommandHandler;
using OCR.Infrastructure.DTO;
using Tesseract;

namespace OCR.Api
{
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
            services.RegisterSwaggerGenServices();
            services.AddSingleton(new TesseractEngine(@"./tessdata", "eng", EngineMode.Default));
            services.AddScoped<IRequestHandler<CreateDocumentCommand, DocumentDTO>, CreateDocumentCommandHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
