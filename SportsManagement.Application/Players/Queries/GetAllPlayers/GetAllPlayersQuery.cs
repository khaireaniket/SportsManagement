using AutoMapper;
using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Application.Players.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Players.Queries.GetAllPlayers
{
    public class GetAllPlayersQuery : IRequest<List<Player>>
    {

    }

    public class GetAllPlayersQueryHandler : BaseHandler, IRequestHandler<GetAllPlayersQuery, List<Player>>
    {
        private readonly ISportsManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPlayersQueryHandler(IUserContext userContext, ISportsManagementDbContext context, IMapper mapper) : base(userContext)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<List<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var teamId = GetTeamId();
            var playersList = _context.Players.Where(p => p.TeamId == teamId).ToList();
            return Task.FromResult(_mapper.Map<List<Player>>(playersList));
        }
    }
}
