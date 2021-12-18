    using InnoTech.LegosForLife.Security.Entities;
using InnoTech.LegosForLife.Security.IServices;
using System.Text;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbSeeder : IAuthDbSeeder
    {
        private readonly AuthDbContext _authDbContext;
        private readonly ISecurityService _securityService;

        public AuthDbSeeder(
            AuthDbContext authDbContext,
            ISecurityService securityService)
        {
            _authDbContext = authDbContext;
            _securityService = securityService;
        }

        public void SeedDevelopment()
        {
            _authDbContext.Database.EnsureDeleted();
            _authDbContext.Database.EnsureCreated();

            var salt = "123#!";

            _authDbContext.AuthUsers.Add(new AuthUserEntity
            {
                Salt = salt,
                HashedPassword = _securityService.HashedPassword(
                    "123456", 
                    Encoding.ASCII.GetBytes(salt)),
                Username = "bud"
            });
            _authDbContext.SaveChanges();
        }
    }
}