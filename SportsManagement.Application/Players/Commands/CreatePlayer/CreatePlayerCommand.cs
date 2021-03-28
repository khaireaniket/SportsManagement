using AutoMapper;
using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set; }

        public string Nationality { get; set; }
    }

    public class CreatePlayerCommandHandler : BaseHandler, IRequestHandler<CreatePlayerCommand, Guid>
    {
        private readonly ISportsManagementDbContext _context;
        private readonly IMapper _mapper;

        public CreatePlayerCommandHandler(IUserContext userContext, ISportsManagementDbContext context, IMapper mapper) : base(userContext)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var playerDomain = (_mapper.Map<Player>(request));
            playerDomain.TeamId = GetTeamId();
            await _context.Players.AddAsync(playerDomain);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(playerDomain.Id);
        }
    }
}
