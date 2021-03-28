using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsManagement.Application.Teams.Queries.GetAllTeams;
using SportsManagement.Application.Teams.Queries.GetFixtures;
using System.Threading.Tasks;

namespace SportsManagement.API.Controllers
{
    /// <summary>
    /// Controller to delegate calls to Team handlers
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint used to fetch all the teams
        /// </summary>
        /// <returns>List of teams</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            var listOfTeams = await _mediator.Send(new GetAllTeamsQuery());

            if (listOfTeams == null || listOfTeams.Count <= 0)
                return NoContent();

            return Ok(listOfTeams);
        }

        /// <summary>
        /// Endpoint used to fetch upcoming/played fixtures
        /// </summary>
        /// <remarks>
        /// **Status enum values**: Upcoming, Played, Postponed, Cancelled
        /// </remarks>
        /// <param name="query">Status input</param>
        /// <returns>List of fixtures</returns>
        [HttpGet("fixtures")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetFixtures([FromQuery] GetFixturesQuery query)
        {
            var listOfFixtures = await _mediator.Send(query);

            if (listOfFixtures == null || listOfFixtures.Count <= 0)
                return NoContent();

            return Ok(listOfFixtures);
        }

        /// <summary>
        /// Endpoint used to demonstrate now unhandled errors are caught in the application
        /// </summary>
        [HttpGet("error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ServerError()
        {
            int i = 0;
            int j = 1 / i;

            await Task.CompletedTask;

            return NoContent();
        }
    }
}
