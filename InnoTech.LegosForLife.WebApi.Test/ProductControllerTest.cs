using InnoTech.LegosForLife.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection;
using Xunit;

namespace InnoTech.LegosForLife.WebApi.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void ProductController_IsOfTypeControllerBase()
        {
            var controller = new ProductController();
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }

        [Fact]
        public void ProductController_UsesApiControllerAttribute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("ApiControllerAttribute"));
            //Assert
            Assert.NotNull(attr);
        }

        [Fact]
        public void ProductController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            //Arrange
            TypeInfo typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
            var routeAttr = attr as RouteAttribute;
            Assert.Equal("api/[controller]", routeAttr.Template);
        }
    }
}
