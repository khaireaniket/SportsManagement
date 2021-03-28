using System;

namespace SportsManagement.Application.Authentication.DTOs
{
    public class UserDetails
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Token { get; set; }
    }
}
