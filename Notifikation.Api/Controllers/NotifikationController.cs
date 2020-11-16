using eDocument.Infrastructure.Controllers;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using System.Threading.Tasks;

namespace Notifikation.Api.Controllers
{
    public class NotifikationController : BasketController
    {
        private IPublishEndpoint publishEndpoint;

        public NotifikationController(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }
        ////[HttpGet("{id}")]
        ////public async Task<ActionResult<NotifikatItemDTO>> GetNotifikatItem(long id)
        ////{
        ////    // var todoItem = await _context.TodoItems.FindAsync(id);

        ////    // if (todoItem == null)
        ////    // {
        ////    //   return NotFound();
        ////    //}
        ////    return null;
        ////    //return todoItem;
        ////}

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] NotifikatItemDTO notifikationModel)
        {
            var createNotifikation = new CreateNotifikationCommand();
            createNotifikation.Notifikation = notifikationModel;
          await  publishEndpoint.Publish(createNotifikation);

            return Ok(new { name ="" });
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
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            //var todoItem = await _context.TodoItems.FindAsync(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //_context.TodoItems.Remove(todoItem);
            //await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
