﻿using FluentValidation;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Domain.Enumerations;
using System;
using System.Linq;

namespace SportsManagement.Application.Players.Commands.UpdatePlayer
{
    public class UpdatePlayerCommandValidator : AbstractValidator<UpdatePlayerCommand>
    {
        private readonly ISportsManagementDbContext _context;

        public UpdatePlayerCommandValidator(ISportsManagementDbContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName).NotNull().NotEmpty();
            RuleFor(x => x.Position).NotNull().NotEmpty();
            RuleFor(x => x.Position).Must(IsValidPosition).WithMessage("'Position' is invalid. Valid Positions are [GoalKeeper, Defender, Midfielder, Attacker ]");
            RuleFor(x => x.Nationality).NotNull().NotEmpty();
            RuleFor(x => x.Nationality).Must(IsValidNationality).WithMessage("'Nationality' is invalid. Valid Nationalities are [Sweden, England, France, Spain, Germany, Scotland, Brazil, Portugal, Norway]");
            RuleFor(x => x.JerseyNumber).GreaterThan(0);
            RuleFor(x => x.JerseyNumber).Must((p, jerseyNumber) => IsValidJerseyNumber(jerseyNumber, p.Id)).WithMessage("'Jersey Number' already assigned");
        }

        private bool IsValidPosition(string position)
        {
            return Enum.IsDefined(typeof(Position), position ?? string.Empty);
        }

        private bool IsValidNationality(string nationality)
        {
            return Enum.IsDefined(typeof(Nationality), nationality ?? string.Empty);
        }

        private bool IsValidJerseyNumber(int jerseyNumber, Guid playerId)
        {
            return !_context.Players.Any(a => a.Id != playerId && a.JerseyNumber == jerseyNumber);
        }
    }
}
