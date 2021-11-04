using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Domain.Services;
using Moq;
using System.IO;
using Xunit;

namespace InnoTech.LegosForLife.Domain.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void ProductService_IsIProductService()
        {
            var mock = new Mock<IProductRepository>();

            var service = new ProductService(mock.Object);
            Assert.True(service is IProductService);
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

            Assert.Equal("ProductRepository Cannot Be Null",exception.Message);
        }
    }
}
