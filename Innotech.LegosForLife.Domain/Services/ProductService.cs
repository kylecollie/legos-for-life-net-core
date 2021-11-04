using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace InnoTech.LegosForLife.Domain.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new InvalidDataException("ProductRepository Cannot Be Null");
            }
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }
    }
}
