using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.Models;
using System.Linq;

namespace InnoTech.LegosForLife.Security.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly AuthDbContext _authDb;

        public AuthUserRepository(AuthDbContext authDb)
        {
            _authDb = authDb;
        }

        public AuthUser FindByUserNameAndPassword(string username, string password)
        {
            var entity = _authDb.AuthUsers
                .FirstOrDefault(user =>
                    password.Equals(user.Password) &&
                    username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                UserName = entity.Username
            };
        }
    }
}


