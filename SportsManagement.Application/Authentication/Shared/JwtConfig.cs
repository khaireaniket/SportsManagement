namespace SportsManagement.Application.Authentication.Shared
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
        public double TokenLifetimeInMin { get; set; }
    }
}
