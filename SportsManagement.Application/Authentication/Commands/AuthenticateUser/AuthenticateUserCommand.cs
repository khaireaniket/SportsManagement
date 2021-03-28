using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SportsManagement.Application.Authentication.DTOs;
using SportsManagement.Application.Authentication.Shared;
using SportsManagement.Application.Common.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Authentication.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<UserDetails>
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, UserDetails>
    {
        private readonly ISportsManagementDbContext _context;
        private readonly IMapper _mapper;
        private readonly JwtConfig _jwtSettings;

        public AuthenticateUserCommandHandler(ISportsManagementDbContext context, IOptions<JwtConfig> jwtSettings, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<UserDetails> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Managers.FirstOrDefault(a => a.UserName == request.UserName.ToLower());
            if (user == null)
            {
                return null;
            }

            var isPasswordValid = user.Password == request.Password;
            if (!isPasswordValid)
            {
                return null;
            }

            JwtSecurityToken jwtSecurityToken = await JwtHelper.GenerateJWToken(user, _jwtSettings);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            
            UserDetails userDetails = CustomMapper(user, jwtToken);

            return await Task.FromResult(userDetails);
        }

        private UserDetails CustomMapper(Domain.Entities.Manager user, string jwtToken)
        {
            return new UserDetails
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = jwtToken
            };
        }
    }
}
