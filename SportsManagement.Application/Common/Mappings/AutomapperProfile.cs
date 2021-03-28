using AutoMapper;
using Entities = SportsManagement.Domain.Entities;
using PlayerDTOs = SportsManagement.Application.Players.DTOs;
using TeamDTOs = SportsManagement.Application.Teams.DTOs;
using CreatePlayer = SportsManagement.Application.Players.Commands.CreatePlayer;
using UpdatePlayer = SportsManagement.Application.Players.Commands.UpdatePlayer;

namespace SportsManagement.Application.Common.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Entities.Player, PlayerDTOs.Player>();
            CreateMap<CreatePlayer.CreatePlayerCommand, Entities.Player>();
            CreateMap<UpdatePlayer.UpdatePlayerCommand, Entities.Player>();

            CreateMap<Entities.Team, TeamDTOs.Team>();
        }
    }
}
