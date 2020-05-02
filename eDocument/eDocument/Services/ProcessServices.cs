using AutoMapper;
using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure;
using eDocument.Services.Interfaces;
using eDocument.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDocument.Services
{
    public class ProcessServices : IProcessServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public ProcessServices(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task AddAsync(ProcessViewModel invoice)
        {
            var item = _mapper.Map<Process>(invoice);
            await _unitOfWork.Process.AddAsync(item);
            _unitOfWork.SaveChanges();
        }

        public void Delete(ProcessViewModel process)
        {
            var item = _mapper.Map<Process>(process);
            _unitOfWork.Process.Remove(item);
            _unitOfWork.SaveChanges();
        }

        public async Task<ICollection<ProcessViewModel>> GetAllAsync()
        {
            var allCustomers = await _unitOfWork.Process.GetAllAsync();
            return _mapper.Map<ICollection<ProcessViewModel>>(allCustomers);
        }

        public async Task<ProcessViewModel> GetByIdAsync(long id)
        {
            var allCustomers = await _unitOfWork.Process.GetAsync(id);
            return _mapper.Map<ProcessViewModel>(allCustomers);
        }

        public void Update(ProcessViewModel process)
        {
            var item = _mapper.Map<Process>(process);
            _unitOfWork.Process.Update(item);
            _unitOfWork.SaveChanges();
        }
    }
}
