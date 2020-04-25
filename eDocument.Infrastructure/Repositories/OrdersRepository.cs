using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.Data;
using eDocument.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eDocument.Infrastructure.Repositories
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(DbContext context) : base(context)
        { }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
