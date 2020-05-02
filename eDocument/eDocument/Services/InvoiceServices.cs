using AutoMapper;
using DocumentTracking.ApplicationCore.Entities;
using eDocument.Infrastructure;
using eDocument.Services.Interfaces;
using eDocument.ViewModels;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDocument.Services
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public InvoiceServices(IUnitOfWork unitOfWork, ILogger logger, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._logger = logger;
            this._mapper = mapper;
        }

        public async Task<ICollection<InvoiceViewModel>> GetAllAsync()
        {
            var allCustomers = await _unitOfWork.Invoices.GetAllAsync();
            return _mapper.Map<ICollection<InvoiceViewModel>>(allCustomers);
        }

        public async Task<InvoiceViewModel> GetByIdAsync(long id)
        {
            var allCustomers = await _unitOfWork.Invoices.GetAsync(id);
            return _mapper.Map<InvoiceViewModel>(allCustomers);
        }

        public async Task AddAsync(InvoiceViewModel invoice)
        {
            Invoice item = _mapper.Map<Invoice>(invoice);
            await _unitOfWork.Invoices.AddAsync(item);
            _unitOfWork.SaveChanges();
        }
     
        public void Update(InvoiceViewModel invoice)
        {
            Invoice item = _mapper.Map<Invoice>(invoice);
            _unitOfWork.Invoices.Update(item);
            _unitOfWork.SaveChanges();
        }

        public void Delete(InvoiceViewModel invoice)
        {
            Invoice item = _mapper.Map<Invoice>(invoice);
            _unitOfWork.Invoices.Remove(item);
            _unitOfWork.SaveChanges();
        }

        public async Task<(bool Succeeded, string[] Errors)> DeleteInvoiceAsync(long invoiceId)
        {
            var invoice = await _unitOfWork.Invoices.GetAsync(invoiceId);

            if (invoice != null)
                return DeleteInvoice(invoice);

            return (true, new string[] { });
        }
        private (bool Succeeded, string[] Errors) DeleteInvoice(Invoice invoice)
        {
             _unitOfWork.Invoices.Remove(invoice);
            return (true, new string[]{});
        }
    }
}
