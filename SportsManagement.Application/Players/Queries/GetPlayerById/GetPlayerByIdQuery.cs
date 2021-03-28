using AutoMapper;
using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Application.Players.DTOs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Players.Queries.GetPlayerById
{
    public class GetPlayerByIdQuery : IRequest<Player>
    {
        public Guid Id { get; set; }
    }

    public class GetPlayerByIdQueryHandler : BaseHandler, IRequestHandler<GetPlayerByIdQuery, Player>
    {
        private readonly ISportsManagementDbContext _context;
        private readonly IMapper _mapper;

        public GetPlayerByIdQueryHandler(IUserContext userContext, ISportsManagementDbContext context, IMapper mapper) : base(userContext)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<Player> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var teamId = GetTeamId();
            var player = _context.Players.SingleOrDefault(a => a.TeamId == teamId && a.Id == request.Id);
            return Task.FromResult(_mapper.Map<Player>(player));
        }
    }
}
