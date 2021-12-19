using InnoTech.LegosForLife.Security.IServices;
using InnoTech.LegosForLife.Security.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace InnoTech.LegosForLife.Security.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IAuthUserService _authUserService;

        public SecurityService(
            IConfiguration configuration,
            IAuthUserService authUserService)
        {
            _authUserService = authUserService;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var user = _authUserService.GetUser(username);
            if (Authenticate(user, password))
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                    Configuration["Jwt:Audience"],
                    null,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials);

                return new JwtToken
                {
                    Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                    Message = "Ok"
                };
            }
            throw new AuthenticationException("User or Password not correct");
        }

        private bool Authenticate(AuthUser user, string plainTextPassword)
        {
            if (user == null || user.HashedPassword.Length <= 0 || user.Salt.Length <= 0) 
                return false;

            var hashedPasswordFromPlain = HashedPassword(plainTextPassword, user.Salt);
            return user.HashedPassword.Equals(hashedPasswordFromPlain);
        }

        public string HashedPassword(string plainTextPassword, byte[] userSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                plainTextPassword,
                userSalt,
                KeyDerivationPrf.HMACSHA256,
                100000,
                256 / 8));
        }

        public AuthUser GenerateNewAuthuser(string username)
        {
            // make default password
            var defaultPassword = "123456";
            byte[] salt = GenerateSalt();

            // generate hashed password
            var hashedPassword = HashedPassword(defaultPassword, salt);

            // create AuthUser with new hashed password and salt
            // pass auth to AuthUser Service
            AuthUser authUser = _authUserService.Create(new AuthUser
            {
                UserName = username,
                HashedPassword = hashedPassword,
                Salt = salt
            });

            // when saved, return new user
            return authUser;

            throw new NotImplementedException();
        }

        public byte[] GenerateSalt()
        {
            // make new salt
            var salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            return salt;
        }
    }
}
