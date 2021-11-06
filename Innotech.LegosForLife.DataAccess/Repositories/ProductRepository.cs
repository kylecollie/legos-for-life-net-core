using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.DataAccess;
using InnoTech.LegosForLife.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.IO;

namespace Innotech.LegosForLife.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(MainDbContext ctx)
        {
            if (ctx == null) throw new InvalidDataException("Product Repository must have a DbContext");
        }

        public List<Product> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}