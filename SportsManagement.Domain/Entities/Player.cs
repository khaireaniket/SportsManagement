using System;

namespace SportsManagement.Domain.Entities
{
    public class Player
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int JerseyNumber { get; set; }

        public string Position { get; set; }

        public string Nationality { get; set; }

        public Guid TeamId { get; set; }
    }
}
