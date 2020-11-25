using Notifikation.Infrastructure.Context;

namespace Notifikation.Infrastructure.Extensions
{
    public static class DatabaseContextExtensions
    {
        public static void Seed(this NotifikationContext context)
        {
            SeedUsers(context);
            context.SaveChanges();
        }

        static void SeedUsers(NotifikationContext context)
        {
        }
    }
}
