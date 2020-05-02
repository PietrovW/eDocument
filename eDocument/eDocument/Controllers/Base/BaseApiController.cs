using AutoMapper;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eDocument.Controllers.Base
{
    [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        public BaseApiController(IMapper mapper)
        {
            Mapper = mapper;
        }
        private IMapper Mapper { get; }
        public IMapper mapper { get { return Mapper; } }
    }
}
