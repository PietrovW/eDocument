using AutoMapper;
using eDocument.Infrastructure.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using System.Net;
using System.Threading.Tasks;

namespace Notifikation.Api.Controllers
{
    public class NotifikationController : BasketController
    {
        public NotifikationController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateNotifikationCommand), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Post([FromBody] CreateNotifikationCommand notifikationModel)
        {
            
            return Created(string.Empty, await mediator.Send(notifikationModel));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(NotifikatItemDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            return Ok(await mediator.Send(new DeleteNotifikationCommand
            {
                Id = id
            }));
        }
    }
}
