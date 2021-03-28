using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsManagement.Application.Players.Commands.CreatePlayer;
using SportsManagement.Application.Players.Commands.DeletePlayer;
using SportsManagement.Application.Players.Commands.UpdatePlayer;
using SportsManagement.Application.Players.Queries.GetAllPlayers;
using SportsManagement.Application.Players.Queries.GetPlayerById;
using System;
using System.Threading.Tasks;

namespace SportsManagement.API.Controllers
{
    /// <summary>
    /// Controller to delegate calls to Player handlers
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Endpoint used to fetch all the players
        /// </summary>
        /// <returns>List of players</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Get()
        {
            var listOfPlayers = await _mediator.Send(new GetAllPlayersQuery());

            if (listOfPlayers == null || listOfPlayers.Count <= 0)
                return NoContent();

            return Ok(listOfPlayers);
        }

        /// <summary>
        /// Endpoint used to fetch a player by playerId
        /// </summary>
        /// <param name="query">Id</param>
        /// <returns>Player details</returns>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] GetPlayerByIdQuery query)
        {
            var player = await _mediator.Send(query);

            if (player == null)
                return NotFound(query.Id);

            return Ok(player);
        }

        /// <summary>
        /// Endpoint used to add a player
        /// </summary>
        /// <remarks>
        /// **Position enum values**: GoalKeeper, Defender, Midfielder, Attacker 
        /// <br /> 
        /// **Nationality enum values**: Sweden, England, France, Spain, Germany, Scotland, Brazil, Portugal, Norway
        /// </remarks>
        /// <param name="command">Player details</param>
        /// <returns>Player Id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] CreatePlayerCommand command)
        {
            var createdPlayerId = await _mediator.Send(command);
            return CreatedAtAction("Get", new { Id = createdPlayerId }, createdPlayerId);
        }

        /// <summary>
        /// Endpoint used to update an existing player
        /// </summary>
        /// <remarks>
        /// **Position enum values**: GoalKeeper, Defender, Midfielder, Attacker 
        /// <br /> 
        /// **Nationality enum values**: Sweden, England, France, Spain, Germany, Scotland, Brazil, Portugal, Norway
        /// </remarks>
        /// <param name="command">Player details</param>
        /// <returns>Player Id</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] UpdatePlayerCommand command)
        {
            var updatePlayerId = await _mediator.Send(command);

            if (updatePlayerId == Guid.Empty)
                return NotFound(command.Id);

            return Ok(updatePlayerId);
        }

        /// <summary>
        /// Endpoint used to remove a player
        /// </summary>
        /// <param name="command">Player details</param>
        /// <returns>No data</returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeletePlayerCommand command)
        {
            var isDeleted = await _mediator.Send(command);

            if (isDeleted == false)
                return NotFound(command.Id);

            return NoContent();
        }
    }
}
