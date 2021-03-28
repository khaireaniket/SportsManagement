using System;

namespace SportsManagement.Domain.Entities
{
    public class Manager : User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Nationality { get; set; }
        
        public Guid TeamId { get; set; }
    }
}
