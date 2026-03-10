using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
    {
        new Product { Id = 1, Name = "Laptop", Price = 80000 },
        new Product { Id = 2, Name = "Mobile", Price = 20000 }
    };

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
            return Ok(product);
        }
    }
}
