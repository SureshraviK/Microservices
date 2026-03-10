using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private static List<Order> orders = new List<Order>();

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(orders);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            orders.Add(order);
            return Ok(order);
        }
    }
}
