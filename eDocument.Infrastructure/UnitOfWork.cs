using eDocument.Infrastructure.Data;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Repositories.Interfaces;

namespace eDocument.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly ApplicationDbContext _context;

        ICustomerRepository _customers;
        IProductRepository _products;
        IOrdersRepository _orders;
        IInvoiceRepository _invoices;
        IProcessRepository _process;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        public ICustomerRepository Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new CustomerRepository(_context);

                return _customers;
            }
        }



        public IProductRepository Products
        {
            get
            {
                if (_products == null)
                    _products = new ProductRepository(_context);

                return _products;
            }
        }

        public IOrdersRepository Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new OrdersRepository(_context);

                return _orders;
            }
        }

        public IInvoiceRepository Invoices
        {
            get
            {
                if (_invoices == null)
                    _invoices = new InvoiceRepository(_context);

                return _invoices;
            }
        }

        public IProcessRepository Process
        {
            get
            {
                if (_process == null)
                    _process = new ProcessRepository(_context);

                return _process;
            }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
