using EntityFrameworkCore.Testing.Moq;
using Innotech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Domain.IRepositories;
using System.IO;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void ProductRepository_IsIProductRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProductRepository(fakeContext);
            Assert.IsAssignableFrom<IProductRepository>(repository);
        }

        [Fact]
        public void ProductRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => new ProductRepository(null));
        }
        
        [Fact]
        public void ProductRepository_WithNullDbContext_ThrowsExceptionWithMessage()
        {
            var exception = Assert
                .Throws<InvalidDataException>(() => new ProductRepository(null));
            Assert.Equal("Product Repository must have a DbContext", exception.Message);
        }
    }
}