using Innotech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.DataAccess;
using System.Linq;

namespace Innotech.LegosForLife.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _context;

        public DbSeeder(MainDbContext context)
        {
            _context = context;
        }

        public void SeedDevelopment()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Products.Add(new ProductEntity { Name = "Lego1" });
            _context.Products.Add(new ProductEntity { Name = "Lego2" });
            _context.Products.Add(new ProductEntity { Name = "Lego3" });
            _context.SaveChanges();
        }

        public void SeedProduction()
        {
            _context.Database.EnsureCreated();
            var cnt = _context.Products.Count();
            if (cnt == 0)
            {
                _context.Products.Add(new ProductEntity { Name = "Lego1" });
                _context.Products.Add(new ProductEntity { Name = "Lego2" });
                _context.Products.Add(new ProductEntity { Name = "Lego3" });
                _context.SaveChanges();
            }
        }
    }
}
