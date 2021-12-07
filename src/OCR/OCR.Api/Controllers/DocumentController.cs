using AutoMapper;
using eDocument.Infrastructure.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OCR.Infrastructure.Command;
using OCR.Infrastructure.DTO;
using System.Net;
using System.Threading.Tasks;

namespace OCR.Api.Controllers
{
    public class DocumentController : BasketController
    {
        public DocumentController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(DocumentDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Post([FromBody] CreateDocumentCommand createDocument)
        {

            return Created(string.Empty, await mediator.Send(createDocument));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            return Ok(await mediator.Send(new DeleteDocumentCommand
            {
                Id = id
            }));
        }
    }
}
