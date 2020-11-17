using Notifikation.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

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
