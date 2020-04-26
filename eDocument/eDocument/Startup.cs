using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using eDocument.Authorization;
using eDocument.Helpers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using eDocument.Filter;
using eDocument.Infrastructure;
using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.Data;
using eDocument.ApplicationCore.Constants;
using eDocument.Infrastructure.EmailSender.Base;
using eDocument.Infrastructure.EmailSender;
using eDocument.ApplicationCore;
using eDocument.ApplicationCore.Interfaces;
using eDocument.Infrastructure.Data.Base;
using eDocument.ApplicationCore.Permissions;
using eDocument.Extensions;
using eDocument.Configs;

namespace eDocument
{
    public class Startup
    {
        private IWebHostEnvironment _env { get; }
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(@"Data Source=eDocumentDB.db;", b => b.MigrationsAssembly("eDocument")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;

                //    //// Password settings
                //    //options.Password.RequireDigit = true;
                //    //options.Password.RequiredLength = 8;
                //    //options.Password.RequireNonAlphanumeric = false;
                //    //options.Password.RequireUppercase = true;
                //    //options.Password.RequireLowercase = false;

                //    //// Lockout settings
                //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //    //options.Lockout.MaxFailedAccessAttempts = 10;
            });


            // Adds IdentityServer.
            services.AddIdentityServer()
                // The AddDeveloperSigningCredential extension creates temporary key material for signing tokens.
                // This might be useful to get started, but needs to be replaced by some persistent key material for production scenarios.
                // See http://docs.identityserver.io/en/release/topics/crypto.html#refcrypto for more information.
                .AddDeveloperSigningCredential()
                .AddInMemoryPersistedGrants()
                
                // To configure IdentityServer to use EntityFramework (EF) as the storage mechanism for configuration data (rather than using the in-memory implementations),
                // see https://identityserver4.readthedocs.io/en/release/quickstarts/8_entity_framework.html
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients())
                .AddAspNetIdentity<ApplicationUser>()
                .AddProfileService<ProfileService>();


            var applicationUrl = Configuration["ApplicationUrl"].TrimEnd('/');

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = applicationUrl;
                    options.SupportedTokens = SupportedTokens.Jwt;
                    options.RequireHttpsMetadata = false; // Note: Set to true in production
                    options.ApiName = IdentityServerConfig.ApiName;
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Authorization.Policies.ViewAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, ApplicationPermissions.ViewUsers));
                options.AddPolicy(Authorization.Policies.ManageAllUsersPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, ApplicationPermissions.ManageUsers));

                options.AddPolicy(Authorization.Policies.ViewAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, ApplicationPermissions.ViewRoles));
                options.AddPolicy(Authorization.Policies.ViewRoleByRoleNamePolicy, policy => policy.Requirements.Add(new ViewRoleAuthorizationRequirement()));
                options.AddPolicy(Authorization.Policies.ManageAllRolesPolicy, policy => policy.RequireClaim(ClaimConstants.Permission, ApplicationPermissions.ManageRoles));

                options.AddPolicy(Authorization.Policies.AssignAllowedRolesPolicy, policy => policy.Requirements.Add(new AssignRolesAuthorizationRequirement()));
            });


            services.AddCors();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //services.AddAppSwaggerGen();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = IdentityServerConfig.ApiFriendlyName, Version = "v1" });
            //    c.OperationFilter<AuthorizeCheckOperationFilter>();
            //    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //    {
            //        Type = SecuritySchemeType.OAuth2,
            //        Flows = new OpenApiOAuthFlows
            //        {
            //            Password = new OpenApiOAuthFlow
            //            {
            //                TokenUrl = new Uri("/connect/token", UriKind.Relative),
            //                Scopes = new Dictionary<string, string>()
            //                {
            //                    { IdentityServerConfig.ApiName, IdentityServerConfig.ApiFriendlyName }
            //                }
            //            }
            //        }
            //    });
            //});

            services.AddAutoMapper(typeof(Startup));

            // Configurations
            services.Configure<AppSettings>(Configuration);


            // Business Services
            services.AddScoped<IEmailSender, EmailSender>();


            // Repositories
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();

            // Auth Handlers
            services.AddSingleton<IAuthorizationHandler, ViewUserAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ManageUserAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, ViewRoleAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AssignRolesAuthorizationHandler>();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            Utilities.ConfigureLogger(loggerFactory);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseIdentityServer();
            app.UseAuthorization();
           // app.UseAppSwagger();
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.DocumentTitle = "Swagger UI - eDocument";
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{IdentityServerConfig.ApiFriendlyName} V1");
            //    c.OAuthClientId(IdentityServerConfig.SwaggerClientID);
            //    c.OAuthClientSecret("no_password"); //Leaving it blank doesn't work
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

            });

           // app.SeedData();

            app.UseSpa(spa =>
            {
               
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(120); // Increase the timeout if angular app is taking longer to startup
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // Use this instead to use the angular cli server
                }
            });

        }
    }
}
