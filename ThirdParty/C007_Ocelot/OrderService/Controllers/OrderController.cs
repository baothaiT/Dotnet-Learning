using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(new[] { "Order1", "Order2", "Order3" });
        }
    }
}
