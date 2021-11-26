using InnoTech.LegosForLife.Security.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace InnoTech.LegosForLife.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthDbContext _authDb;

        public SecurityService(IConfiguration configuration, AuthDbContext authDb)
        {
            _configuration = configuration;
            _authDb = authDb;
        }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                null,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtToken
            {
                Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Ok"
            };
        }
    }
}
