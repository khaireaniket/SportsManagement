using FluentValidation;
using System;

namespace SportsManagement.Application.Players.Queries.GetPlayerById
{
    public class GetPlayerByIdQueryValidator : AbstractValidator<GetPlayerByIdQuery>
    {
        public GetPlayerByIdQueryValidator()
        {
            RuleFor(x => x.Id).Must(IsValidGuid).WithMessage("PlayerId is required");
        }

        private bool IsValidGuid(Guid playerId)
        {
            return playerId != Guid.Empty;
        }
    }
}
