using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> Products = new List<Product>
    {
        new Product
        {
            Id=1,
            Name="Test",
            Price=15,
            Stock=5,
            ImageUrl="https://cdn.vatanbilgisayar.com/Upload/PRODUCT/asus/thumb/TeoriV2-103670_large.jpg"
        },
          new Product
        {
            Id=2,
            Name="Test2",
            Price=15,
            Stock=5,
            ImageUrl="https://www.amd.com/system/files/2019-06/237107-rx5700xt-gpu-gallery2-1260x709.png"
        }
    };
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(Products);
        }
    }
}
