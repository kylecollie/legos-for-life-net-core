﻿using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using System.Collections.Generic;
using System.IO;

namespace InnoTech.LegosForLife.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new InvalidDataException("ProductRepository Cannot Be Null");
        }

        public List<Product> GetProducts()
        {
            return _productRepository.FindAll();
        }
    }
}
