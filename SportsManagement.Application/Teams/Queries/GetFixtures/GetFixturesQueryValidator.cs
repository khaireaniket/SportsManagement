using FluentValidation;
using SportsManagement.Domain.Enumerations;
using System;

namespace SportsManagement.Application.Teams.Queries.GetFixtures
{
    public class GetFixturesQueryValidator : AbstractValidator<GetFixturesQuery>
    {
        public GetFixturesQueryValidator()
        {
            RuleFor(x => x.Status).Must(IsValidFixtureStatus).WithMessage("Status is invalid. Valid Statuses are [Upcoming, Played, Postponed, Cancelled]");
        }

        private bool IsValidFixtureStatus(string status)
        {
            return Enum.IsDefined(typeof(FixtureStatus), status ?? string.Empty);
        }
    }
}
