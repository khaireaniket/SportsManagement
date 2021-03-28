using SportsManagement.Domain.Enumerations;
using System;

namespace SportsManagement.Domain.Entities
{
    public class Fixture
    {
        public Guid Id { get; set; }

        public Guid HomeTeamId { get; set; }

        public Guid AwayTeamId { get; set; }

        public string Score { get; set; }

        public DateTime FixtureDate { get; set; }

        public FixtureStatus FixtureStatus { get; set; }
    }
}
