using InnoTech.LegosForLife.Core.Models;
using Xunit;

namespace InnoTech.LegosForLife.Core.Test.Models
{
    public class ProductTest
    {
        [Fact]
        public void Product_CanBeInitialized()
        {
            Product product = new();
            Assert.NotNull(product);
        }
    }
}
