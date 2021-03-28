using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeletePlayerCommandHandler : BaseHandler, IRequestHandler<DeletePlayerCommand, bool>
    {
        private readonly ISportsManagementDbContext _context;

        public DeletePlayerCommandHandler(IUserContext userContext, ISportsManagementDbContext context) : base(userContext)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            var teamId = GetTeamId();
            var playerToDelete = _context.Players.SingleOrDefault(a => a.TeamId == teamId && a.Id == request.Id);

            if (playerToDelete == null)
            {
                return await Task.FromResult(false);
            }

            _context.Players.Remove(playerToDelete);
            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(true);
        }
    }
}
