using eDocument.Infrastructure.Repositories.Interfaces;

namespace eDocument.Infrastructure
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }

        IProductRepository Products { get; }

        IOrdersRepository Orders { get; }

        IInvoiceRepository Invoices { get; }

        IProcessRepository Process { get; }
        int SaveChanges();
    }
}
