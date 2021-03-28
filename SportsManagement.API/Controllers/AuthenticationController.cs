using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsManagement.Application.Authentication.Commands.AuthenticateUser;
using System.Threading.Tasks;

namespace SportsManagement.API.Controllers
{
    /// <summary>
    /// Controller to delegate calls to Authentication handlers
    /// </summary>
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint used to login into application
        /// </summary>
        /// <returns>List of players</returns>
        [HttpPost, AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserCommand authenticateUserCommand)
        {
            var userDetails = await _mediator.Send(authenticateUserCommand);

            if (userDetails == null)
                return Unauthorized();

            return Ok(userDetails);
        }
    }
}
