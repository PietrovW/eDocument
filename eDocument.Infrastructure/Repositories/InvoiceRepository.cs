using DocumentTracking.ApplicationCore.Entities;
using eDocument.Infrastructure.Data;
using eDocument.Infrastructure.Repositories.Interfaces;

namespace eDocument.Infrastructure.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
