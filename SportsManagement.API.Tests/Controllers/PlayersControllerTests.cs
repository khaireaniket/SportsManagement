using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsManagement.API.Tests.Controllers.Base;
using SportsManagement.Application.Players.DTOs;
using SportsManagement.Application.Players.Queries.GetAllPlayers;
using SportsManagement.Application.Players.Queries.GetPlayerById;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SportsManagement.API.Tests.Controllers
{
    public class PlayersControllerTests : PlayersControllerTestsBase
    {
        [Fact]
        public async Task GetAllPlayers_Returns_Ok_With_ListOfPlayers()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetAllPlayersQuery>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.FromResult(_listOfPlayers));

            // Act
            var result = await _playersController.Get();

            // Assert
            Assert.NotNull(result);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(okObjectResult.Value);

            var allPlayers = (List<Player>)okObjectResult.Value;

            Assert.NotNull(allPlayers);
            Assert.Equal(_listOfPlayers.Count, allPlayers.Count);
            Assert.Equal(_listOfPlayers.First().Id, allPlayers.First().Id);
        }

        [Fact]
        public async Task GetAllPlayers_Returns_NoContent_With_EmptyResponse()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetAllPlayersQuery>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.FromResult(_emptyListOfPlayers));

            // Act
            var result = await _playersController.Get();

            // Assert
            Assert.NotNull(result);

            var noContentObjectResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentObjectResult.StatusCode);
        }

        [Fact]
        public async Task GetPlayerById_Returns_Ok_With_PlayerDetails()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetPlayerByIdQuery>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.FromResult(_player));

            // Act
            var result = await _playersController.Get(new GetPlayerByIdQuery { Id = _playerId });

            // Assert
            Assert.NotNull(result);

            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okObjectResult.StatusCode);
            Assert.NotNull(okObjectResult.Value);

            var singlePlayer = (Player)okObjectResult.Value;

            Assert.NotNull(singlePlayer);
            Assert.Equal(_player.Id, singlePlayer.Id);
        }

        [Fact]
        public async Task GetPlayerById_Returns_NotFound_With_EmptyResponse()
        {
            // Arrange
            _mediator.Setup(x => x.Send(It.IsAny<GetPlayerByIdQuery>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.FromResult(_nullPlayer));

            // Act
            var result = await _playersController.Get(new GetPlayerByIdQuery());

            // Assert
            Assert.NotNull(result);

            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(404, notFoundObjectResult.StatusCode);
        }
    }
}
