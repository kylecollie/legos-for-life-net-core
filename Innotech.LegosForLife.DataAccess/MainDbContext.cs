using InnoTech.LegosForLife.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.LegosForLife.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}