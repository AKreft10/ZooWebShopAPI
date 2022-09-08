using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZooWebShopAPI.DataAccess;
using ZooWebShopAPI.DataAccess.QueryDataAccess;
using ZooWebShopAPI.Entities;
using ZooWebShopAPI.Exceptions;
using ZooWebShopAPI.Feautures.Accounts.Commands;

namespace ZooWebShopAPI.Feautures.Accounts.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IQueryDataAccess _dataAccess;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginUserHandler(IQueryDataAccess dataAccess, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dataAccess = dataAccess;
            _authenticationSettings = authenticationSettings;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _dataAccess.GetUserByGivenLoginCredentials(request.dto);
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.dto.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new BadRequestException("Invalid usename or password");

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }
    }
}
