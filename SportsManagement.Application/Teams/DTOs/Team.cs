using System;

namespace SportsManagement.Application.Teams.DTOs
{
    public class Team
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Manager { get; set; }
    }
}
