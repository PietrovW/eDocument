using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.Data;
using eDocument.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDocument.Infrastructure.Repositories
{
    public class ProcessRepository : Repository<Process>, IProcessRepository
    {
        public ProcessRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
