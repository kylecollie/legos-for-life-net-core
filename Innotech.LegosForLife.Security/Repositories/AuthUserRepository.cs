using InnoTech.LegosForLife.Security.Entities;
using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.Models;
using System;
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
                Salt = Convert.FromBase64String(entity.Salt)
            };
        }

        public AuthUser Save(AuthUser authUser)
        {
            var entity = _authDb.Add(new AuthUserEntity
            {
                HashedPassword = authUser.HashedPassword,
                Salt = Convert.ToBase64String(authUser.Salt),
                Username = authUser.UserName
            }).Entity;
            _authDb.SaveChanges();
            return new AuthUser
            {
                UserName = entity.Username,
                Id = entity.Id,

            };
        }
    }
}


