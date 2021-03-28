using System;

namespace SportsManagement.Application.Teams.DTOs
{
    public class Fixture
    {
        public Guid Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public string Score { get; set; }

        public DateTime FixtureDate { get; set; }
    }
}
