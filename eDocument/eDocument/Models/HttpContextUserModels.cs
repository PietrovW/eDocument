using eDocument.ApplicationCore.Constants;
using eDocument.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace eDocument.Models
{
    public class HttpContextUserModels : IContextUserModels
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public HttpContextUserModels(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        public string CurrentUserId()
        {
            return _httpAccessor.HttpContext?.User.FindFirst(ClaimConstants.Subject)?.Value?.Trim();
        }


        public string[] GetRoles()
        {
            return _httpAccessor.HttpContext?.User.Claims
                .Where(c => c.Type == IdentityModel.JwtClaimTypes.Role)
                .Select(c => c.Value)
                .ToArray();
        }

    }
}
