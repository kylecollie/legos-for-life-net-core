using Innotech.LegosForLife.DataAccess.Entities;
using InnoTech.LegosForLife.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
