using AutoMapper;
using eDocument.Controllers.Base;
using eDocument.Services.Interfaces;
using eDocument.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eDocument.Controllers
{
    public class InvoiceController : BaseApiController
    {
        private readonly IInvoiceServices _invoiceServices;
        private readonly ILogger _logger;
        public InvoiceController(IMapper mapper, IInvoiceServices invoiceServices, ILogger<CustomerController> logger) : base(mapper)
        {
            _invoiceServices = invoiceServices;
            _logger = logger;
        }


        [HttpGet]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(List<InvoiceViewModel>))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _invoiceServices.GetAllAsync());
        }

        // GET api/values/5
        [HttpGet("{InvoiceId}", Name = "GetInvoice")]
        [ProducesResponseType(200, Type = typeof(InvoiceViewModel))]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(long InvoiceId)
        {
            var invoice = await _invoiceServices.GetByIdAsync(InvoiceId);

            if (invoice != null)
                return Ok(invoice);
            else
                return NotFound(InvoiceId);
        }

        // POST api/values
        [HttpPost]
        [Authorize(Authorization.Policies.ManageAllUsersPolicy)]
        [ProducesResponseType(201, Type = typeof(InvoiceViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Post([FromBody]InvoiceViewModel invoice)
        {
            await _invoiceServices.AddAsync(invoice);
            return CreatedAtRoute("GetInvoice", new { InvoiceId = invoice.Id }, invoice);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]InvoiceViewModel invoice)
        {
            _invoiceServices.Update(invoice);
            return AcceptedAtAction("GetInvoice", new { InvoiceId = invoice.Id }, invoice);
        }

        [HttpDelete("deleteinvoice/{id}")]
        [ProducesResponseType(200, Type = typeof(InvoiceViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            InvoiceViewModel invoiceVM = await _invoiceServices.GetByIdAsync(id);
            if (invoiceVM == null)
                return NotFound(id);

            _invoiceServices.Delete(invoiceVM);

            return Ok(invoiceVM);
        }
    }
}