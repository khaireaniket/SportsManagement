using AutoMapper;
using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Application.Teams.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Teams.Queries.GetAllTeams
{
    public class GetAllTeamsQuery : IRequest<List<Team>>
    {

    }

    public class GetAllTeamsQueryHandler : BaseHandler, IRequestHandler<GetAllTeamsQuery, List<Team>>
    {
        private readonly ISportsManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTeamsQueryHandler(IUserContext userContext, ISportsManagementDbContext context, IMapper mapper) : base(userContext)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teamsList = _context.Teams.ToList();
            List<Team> dtoTeams = CustomMapper(teamsList);
            return Task.FromResult(dtoTeams);
        }

        private List<Team> CustomMapper(List<Domain.Entities.Team> teamsList)
        {
            List<Team> dtoTeams = new List<Team>();
            foreach (var team in teamsList)
            {
                var manager = _context.Managers.First(a => a.Id == team.ManagerId);
                dtoTeams.Add(new Team
                {
                    Id = team.Id,
                    Name = team.Name,
                    Code = team.Code,
                    Manager = $"{manager.FirstName} {manager.LastName}"
                });
            }

            return dtoTeams;
        }
    }
}
