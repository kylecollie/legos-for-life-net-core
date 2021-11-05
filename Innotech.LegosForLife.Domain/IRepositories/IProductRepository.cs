using InnoTech.LegosForLife.Core.Models;
using System.Collections.Generic;

namespace InnoTech.LegosForLife.Domain.IRepositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
    }
}
