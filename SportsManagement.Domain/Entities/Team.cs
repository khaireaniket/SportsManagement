using System;
using System.Collections.Generic;

namespace SportsManagement.Domain.Entities
{
    public class Team
    {
        public Team()
        {
            Players = new List<Player>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public Guid ManagerId { get; set; }

        public ICollection<Player> Players { get; set; }
    }

}
