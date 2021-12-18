 using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.Models;
using System.Linq;
using System.Text;

namespace InnoTech.LegosForLife.Security.Repositories
{
    public class AuthUserRepository : IAuthUserRepository
    {
        private readonly AuthDbContext _authDb;

        public AuthUserRepository(AuthDbContext authDb)
        {
            _authDb = authDb;
        }

        public AuthUser FindByUserNameAndPassword(string username, string hashedPassword)
        {
            var entity = _authDb.AuthUsers
                .FirstOrDefault(user =>
                    hashedPassword.Equals(user.HashedPassword) &&
                    username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                UserName = entity.Username
            };
        }

        public AuthUser FindUser(string username)
        {
            var entity = _authDb.AuthUsers
                .FirstOrDefault(user =>
                    username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                UserName = entity.Username,
                HashedPassword = entity.HashedPassword,
                Salt = Encoding.ASCII.GetBytes(entity.Salt)
            };
        }
    }
}


