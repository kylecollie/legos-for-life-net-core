using InnoTech.LegosForLife.Core.Models;
using System.Collections.Generic;

namespace InnoTech.LegosForLife.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
