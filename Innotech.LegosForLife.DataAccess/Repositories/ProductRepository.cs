using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess;
using InnoTech.LegosForLife.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Innotech.LegosForLife.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainDbContext _ctx;

        public ProductRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Product Repository must have a DbContext");
            _ctx = ctx;
        }

        public List<Product> FindAll()
        {
            return _ctx.Products
                .Select(pe => new Product { Id = pe.Id, Name = pe.Name })
                .ToList();
        }
    }
}