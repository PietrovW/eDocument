using Microsoft.EntityFrameworkCore;

namespace eDocument.Infrastructure.Seed
{
    public interface IMigrationSeed
    {
        void Initialize();
        void Seed();
    }
}
