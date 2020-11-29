using eDocument.Infrastructure.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDocument.Infrastructure.Extensions
{
    public class DatabaseContextExtensions
    {
        private static void UpdateDatabase(IApplicationBuilder app, bool isSeed = false)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<DbContext>();
                if (context.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                {
                    context.Database.Migrate();
                }
                if (isSeed)
                {
                 //   using IMigrationSeed seed = serviceScope.ServiceProvider.GetService<IMigrationSeed>();
                    // context.Seed();
                }
            }
        }
    }
}
