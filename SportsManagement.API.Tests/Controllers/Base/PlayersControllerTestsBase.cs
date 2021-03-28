using MediatR;
using Moq;
using SportsManagement.API.Controllers;
using SportsManagement.Application.Players.DTOs;
using System;
using System.Collections.Generic;

namespace SportsManagement.API.Tests.Controllers.Base
{
    public abstract class PlayersControllerTestsBase
    {
        protected readonly Mock<IMediator> _mediator;
        protected readonly PlayersController _playersController;
        protected readonly Guid _playerId = Guid.NewGuid();
        protected Player _player;
        protected List<Player> _listOfPlayers;
        protected Player _nullPlayer;
        protected List<Player> _emptyListOfPlayers;

        protected PlayersControllerTestsBase()
        {
            _mediator = new Mock<IMediator>();
            _playersController = new PlayersController(_mediator.Object);

            _player = new Player
            {
                Id = _playerId,
                FirstName = "FirstName",
                LastName = "LastName",
                JerseyNumber = 1,
                Nationality = "Sweden",
                Position = "Attacker"
            };
            _listOfPlayers = new List<Player> { _player };

            _emptyListOfPlayers = new List<Player>();
        }
    }
}
