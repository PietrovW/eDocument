using AutoMapper;
using eDocument.Controllers.Base;
using eDocument.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace eDocument.Controllers
{
    public class ProcessController : BaseApiController
    {
        private readonly IProcessServices _processServices;
        private readonly ILogger _logger;
        public ProcessController(IMapper mapper, IProcessServices processServices, ILogger<ProcessController> logger) : base(mapper)
        {
            _processServices = processServices;
            _logger = logger;
        }

    }
}
