using eDocument.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eDocument.Extensions
{
    public static class ConfigureDbContextExtensions
    {
        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration config)
        {
           // var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(@"Data Source=eDocumentDB.db;", b => b.MigrationsAssembly("eDocument")));
        }
    }
}
