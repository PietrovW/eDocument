using eDocument.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDocument.Services.Interfaces
{
    public interface IInvoiceServices
    {
        Task<ICollection<InvoiceViewModel>> GetAllAsync();
        Task<InvoiceViewModel> GetByIdAsync(long id);
        Task AddAsync(InvoiceViewModel invoice);
        void Update(InvoiceViewModel invoice);
        void Delete(InvoiceViewModel invoice);
    }
}
