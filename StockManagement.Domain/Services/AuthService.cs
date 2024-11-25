using Microsoft.IdentityModel.Tokens;
using StockManagement.Domain.Entities;
using StockManagement.Domain.Exceptions;
using StockManagement.Domain.Interfaces;
using StockManagement.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace StockManagement.Domain.Services
{
    public class AuthService
    {

        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginResponseModel Authorize(string username, string password)
        {
            User user = _userRepository.GetByUsername(username).Result;

            if (user == null)
                throw new UnAuthorizedException("invalid credentials");

            if (_userRepository.VerifyPassword(user, password) == false)
                throw new UnAuthorizedException("invalid credentials");

            string token = GenerateJwtToken(user);

            LoginResponseModel model = new LoginResponseModel
            {
                IsFirstLogin = user.IsFirstLogin,
                Token = token,
                FullName = user.FirstName + " " + user.LastName,
                userId = user.Id.ToString()
            };

            return model;
        }

        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("6e2bde2e69faed946c60f38b4c2a86a4d6f4d45956bb2c9bc6c51228cc2d590f"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role.GetHashCode().ToString())
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
