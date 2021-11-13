using AutoMapper;
using eDocument.Infrastructure.Controllers;
using MediatR;

namespace OCR.Api.Controllers
{
    public class DocumentController : BasketController
    {
        public DocumentController(IMapper mapper, IMediator mediator) : base(mapper, mediator)
        {
        }
    }
}
