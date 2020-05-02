using eDocument.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eDocument.Extensions
{
    public static class DataSeederExtensions
    {
        public static void SeedData(this IApplicationBuilder app)
        {

            var applicationDbContext = app.ApplicationServices.GetService<ApplicationDbContext>();

            if (!applicationDbContext.Database.EnsureCreated())
            {
                applicationDbContext.Database.Migrate();
            }
        }
    }
}
