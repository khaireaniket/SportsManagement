using FluentValidation;
using System;

namespace SportsManagement.Application.Players.Commands.DeletePlayer
{
    public class DeletePlayerCommandValidator : AbstractValidator<DeletePlayerCommand>
    {
        public DeletePlayerCommandValidator()
        {
            RuleFor(x => x.Id).Must(IsValidGuid).WithMessage("PlayerId is required");
        }

        private bool IsValidGuid(Guid playerId)
        {
            return playerId != Guid.Empty;
        }
    }
}
