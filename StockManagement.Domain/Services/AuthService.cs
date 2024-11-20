using Microsoft.IdentityModel.Tokens;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Domain.Services
{
    public class AuthService
    {

        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result<string> Authorize(string username, string password)
        {
            User user = _userRepository.Get(username, password).Result;

            if (user == null)
            {
                return Result<string>.Failure("invalid credentials", HttpStatusCode.Unauthorized);
            }

            string token = GenerateJwtToken(user);
            return Result<string>.Success(token);
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6e2bde2e69faed946c60f38b4c2a86a4d6f4d45956bb2c9bc6c51228cc2d590f"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: "StockManagement",
                audience: "StockManagement",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
