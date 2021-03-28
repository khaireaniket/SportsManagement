using FluentValidation;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Domain.Enumerations;
using System;
using System.Linq;

namespace SportsManagement.Application.Players.Commands.CreatePlayer
{
    public class CreatePlayerCommandValidator : AbstractValidator<CreatePlayerCommand>
    {
        private readonly ISportsManagementDbContext _context;

        public CreatePlayerCommandValidator(ISportsManagementDbContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.Position).NotNull().NotEmpty();
            RuleFor(x => x.Position).Must(IsValidPosition).WithMessage("'Position' is invalid. Valid Positions are [GoalKeeper, Defender, Midfielder, Attacker ]");
            RuleFor(x => x.Nationality).NotNull().NotEmpty();
            RuleFor(x => x.Nationality).Must(IsValidNationality).WithMessage("'Nationality' is invalid. Valid Nationalities are [Sweden, England, France, Spain, Germany, Scotland, Brazil, Portugal, Norway]");
            RuleFor(x => x.JerseyNumber).GreaterThan(0);
            RuleFor(x => x.JerseyNumber).Must(IsValidJerseyNumber).WithMessage("'Jersey Number' already assigned");
        }

        private bool IsValidPosition(string position)
        {
            return Enum.IsDefined(typeof(Position), position ?? string.Empty);
        }

        private bool IsValidNationality(string nationality)
        {
            return Enum.IsDefined(typeof(Nationality), nationality ?? string.Empty);
        }

        private bool IsValidJerseyNumber(int jerseyNumber)
        {
            return !_context.Players.Any(a => a.JerseyNumber == jerseyNumber);
        }
    }
}
