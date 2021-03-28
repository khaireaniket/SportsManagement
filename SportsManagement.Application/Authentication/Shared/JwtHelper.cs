using Microsoft.IdentityModel.Tokens;
using SportsManagement.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SportsManagement.Application.Authentication.Shared
{
    public static class JwtHelper
    {
        public static Task<JwtSecurityToken> GenerateJWToken(Manager user, JwtConfig jwtSettings)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("Id", user.Id.ToString()),
                new Claim("TeamId", user.TeamId.ToString()),
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return Task.FromResult(jwtSecurityToken);
        }
    }
}
