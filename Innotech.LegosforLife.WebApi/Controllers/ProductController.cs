using InnoTech.LegosForLife.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ActionResult<List<Product>> GetAll()
        {
            return null;
        }
    }
}
