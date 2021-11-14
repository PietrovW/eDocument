using AutoMapper;
using eDocument.Infrastructure.Controllers;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifikation.Api.Models;
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
        ////[HttpPut("{id}")]
        ////public async Task<IActionResult> PutTodoItem(long id, NotifikatItemDTO todoItem)
        ////{

        //// //   _context.Entry(todoItem).State = EntityState.Modified;

        ////   // try
        ////   // {
        ////   /////     await _context.SaveChangesAsync();
        ////   // }
        ////   // catch (DbUpdateConcurrencyException)
        ////   // {
        ////   //     if (!TodoItemExists(id))
        ////   //     {
        ////   //         return NotFound();
        ////   //     }
        ////   //     else
        ////   //     {
        ////   //         throw;
        ////   //     }
        ////   // }

        ////    return NoContent();
        ////}

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
