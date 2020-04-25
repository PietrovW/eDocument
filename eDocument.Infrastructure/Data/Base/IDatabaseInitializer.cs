using System;
using System.Threading.Tasks;

namespace eDocument.Infrastructure.Data.Base
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
