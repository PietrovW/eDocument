using Microsoft.EntityFrameworkCore;
using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.Repositories.Interfaces;
using eDocument.Infrastructure.Data;

namespace eDocument.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
