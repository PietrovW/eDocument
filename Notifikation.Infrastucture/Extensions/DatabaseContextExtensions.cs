using Notifikation.Infrastructure.Context;
using Notifikation.Infrastructure.Entity;
using System.Collections.Generic;
using System.Linq;

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
            if (!context.Users.Any())
            {
                var countries = new List<UserEntity>()
            {
                new UserEntity() { Email = "testc@test.pl", Name = "Test" , Id =1  },
                new UserEntity() { Email = "testc2@test.pl", Name = "Test2" , Id =2  },
                new UserEntity() { Email = "testc3@test.pl", Name = "Test3" , Id =3  }
            };
                context.AddRange(countries);
                context.SaveChanges();
            }
        }
    }
}
