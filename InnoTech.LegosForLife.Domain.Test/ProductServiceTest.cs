﻿using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using InnoTech.LegosForLife.Domain.IRepositories;
using InnoTech.LegosForLife.Domain.Services;
using Moq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductServiceTest
    {
        private readonly Mock<IProductRepository> _mock;
        private readonly ProductService _service;
        private readonly List<Product> _expected;

        public ProductServiceTest()
        {
            _mock = new Mock<IProductRepository>();
            _service = new ProductService(_mock.Object);
            _expected = new List<Product>
            {
                new Product { Id = 1, Name = "Lego1"},
                new Product { Id = 2, Name = "Lego2"}
            };
        }

        [Fact]
        public void ProductService_IsIProductService()
        {
            Assert.True(_service is IProductService);
        }

        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(
                () => new ProductService(null));
        }

        [Fact]
        public void ProductService_WithNullProductRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                () => new ProductService(null));

            Assert.Equal("ProductRepository Cannot Be Null", exception.Message);
        }

        [Fact]
        public void GetProducts_CallsProductRepositoryFindAll_ExactlyOnce()
        {
            _service.GetProducts();
            _mock.Verify(r => r.FindAll(), Times.Once);
        }

        [Fact]
        public void GetProducts_NoFilter_ReturnsListOfAllProducts()
        {
            _mock.Setup(r => r.FindAll())
                .Returns(_expected);
            var actual = _service.GetProducts();
            Assert.Equal(_expected, actual);
        }
    }
}
