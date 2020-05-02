using eDocument.Configs;
using eDocument.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;

namespace eDocument.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseSwagger();
            applicationBuilder.UseSwaggerUI(c =>
            {
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
                c.EnableDeepLinking();
                ////  c.DisplayOperationId();
                //  c.DisplayRequestDuration();
                //  c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(2);
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelRendering(ModelRendering.Model);
                //  c.SwaggerEndpoint($"/swagger/swagger.json", "Version 1.0");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{IdentityServerConfig.ApiFriendlyName} V1");
                c.OAuthClientId(IdentityServerConfig.SwaggerClientID);
                c.OAuthClientSecret("no_password"); //Leaving it blank doesn't work
            });

            return applicationBuilder;
        }

        public static IServiceCollection AddAppSwaggerGen(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2.0", new OpenApiInfo
                {
                    Version = "v2.0",
                    Title = "ASP.NET Core 3 API Clean Architecture",
                    Description = "A sample RESTFul ASP.NET Core 3 API"

                });
                c.OperationFilter<AuthorizeCheckOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Password = new OpenApiOAuthFlow
                        {
                            TokenUrl = new Uri("/connect/token", UriKind.Relative),
                            Scopes = new Dictionary<string, string>()
                                {
                                    { IdentityServerConfig.ApiName, IdentityServerConfig.ApiFriendlyName }
                                }
                        }
                    }
                });
                //c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});

                //var security = new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                Type = ReferenceType.SecurityScheme,
                //                Id = "Bearer"
                //            },
                //            Scheme = "oauth2",
                //            Name = "Bearer",
                //            In = ParameterLocation.Header,
                //        },
                //        new List<string>()

                //    }
                //};
                //c.AddSecurityRequirement(security);
            });

            return serviceCollection;
        }
    }
}
