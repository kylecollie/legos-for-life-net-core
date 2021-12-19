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

            _securityService.GenerateNewAuthuser("bud");
        }
    }
}