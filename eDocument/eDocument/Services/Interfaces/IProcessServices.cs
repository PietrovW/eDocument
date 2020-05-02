using eDocument.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDocument.Services.Interfaces
{
    public interface IProcessServices
    {
        Task<ICollection<ProcessViewModel>> GetAllAsync();
        Task<ProcessViewModel> GetByIdAsync(long id);
        Task AddAsync(ProcessViewModel invoice);
        void Update(ProcessViewModel invoice);
        void Delete(ProcessViewModel invoice);
    }
}
