using Microsoft.AspNetCore.Http;
using SportsManagement.Application.Common.Interface;

namespace SportsManagement.API.Context
{
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }
        public HttpContext HttpContext => _httpContextAccessor.HttpContext;
    }
}
