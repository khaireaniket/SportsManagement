using SportsManagement.Application.Common.Interface;
using System;
using System.Linq;
using System.Security.Claims;

namespace SportsManagement.Application.Common.Base
{
    public class BaseHandler
    {
        private readonly IUserContext _userContext;

        public BaseHandler(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public Guid GetTeamId()
        {
            var loggedInUser = _userContext.HttpContext.User.Identity as ClaimsIdentity;
            var teamId = loggedInUser.Claims.FirstOrDefault(a => a.Type == "TeamId").Value;
            return Guid.Parse(teamId);
        }
    }
}
