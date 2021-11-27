using InnoTech.LegosForLife.Security.Entities;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbSeeder : IAuthDbSeeder
    {
        private readonly AuthDbContext _authDbContext;

        public AuthDbSeeder(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public void SeedDevelopment()
        {
            _authDbContext.Database.EnsureDeleted();
            _authDbContext.Database.EnsureCreated();

            _authDbContext.AuthUsers.Add(new AuthUserEntity
            {
                Password = "123456",
                Username = "bud"
            });
            _authDbContext.SaveChanges();
        }
    }
}