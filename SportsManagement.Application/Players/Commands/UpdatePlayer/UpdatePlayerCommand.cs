using AutoMapper;
using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set; }

        public string Nationality { get; set; }
    }

    public class UpdatePlayerCommandHandler : BaseHandler, IRequestHandler<UpdatePlayerCommand, Guid>
    {
        private readonly ISportsManagementDbContext _context;

        public UpdatePlayerCommandHandler(IUserContext userContext, ISportsManagementDbContext context) : base(userContext)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            var teamId = GetTeamId();
            var storedPlayer = _context.Players.SingleOrDefault(a => a.TeamId == teamId && a.Id == request.Id);

            if (storedPlayer == null)
            {
                return await Task.FromResult(Guid.Empty);
            }

            storedPlayer.FirstName = request.FirstName;
            storedPlayer.LastName = request.LastName;
            storedPlayer.JerseyNumber = request.JerseyNumber;
            storedPlayer.Nationality = request.Nationality;
            storedPlayer.Position = request.Position;

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(storedPlayer.Id);
        }
    }
}
