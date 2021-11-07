using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(IProductService productService)
        {
            if (productService is null)
            {
                throw new InvalidDataException("ProductService Cannot Be Null");
            }
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return null;
        }
    }
}
