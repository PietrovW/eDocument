using AutoMapper;
using eDocument.Infrastructure.Controllers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notifikation.Api.Models;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Queries;
using System.Net;
using System.Threading.Tasks;

namespace Notifikation.Api.Controllers
{
    public class UserController : BasketController
    {

        public UserController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            return Ok(await mediator.Send(new GetUserQueries
            {
                Id = id
            }));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.Created)]
        public async Task<ActionResult> Post([FromBody] UserModel userModel)
        {

            return Created(string.Empty, await mediator.Send(new CreateUserCommand
            {
                User = mapper.Map<UserDTO>(userModel)
            }));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            return Ok(await mediator.Send(new DeleteUserCommand
            {
                Id = id
            }));
        }
    }
}
