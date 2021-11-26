using InnoTech.LegosForLife.Security.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options) { }

        public DbSet<LoginUserEntity> LoginUsers { get; set; }
    }
}
