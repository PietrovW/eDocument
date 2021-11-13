using Microsoft.AspNetCore.Mvc;
using MassTransit;
using MediatR;
using AutoMapper;

namespace eDocument.Infrastructure.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BasketController : ControllerBase
    {
        public readonly IMapper mapper;
        public readonly IMediator mediator;
        public BasketController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
    }
}
