using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.Models;

namespace taskTwoAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public OrdersController(MyDbContext db)
        {

        _db = db;
        
        }

        [HttpGet]
        public IActionResult GetallOrders()
        {
            var orders = _db.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOrderById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var orders=_db.Orders.FirstOrDefault(o => o.OrderId == id);
            return Ok(orders);
        }

        [HttpGet("{date}")]
        public IActionResult getOrderDate(int id)
        { 
            if(id <= 0)
                return BadRequest();
            var orders=_db.Orders.FirstOrDefault(o => o.OrderId == id);
            return Ok(orders);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteOrder(int id)
        {
            if (id<=0) return BadRequest();
            var order= _db.Orders.FirstOrDefault(o=>o.OrderId == id);
            if (order!=null)
                _db.Orders.Remove(order);
                  _db.SaveChanges();
            return NotFound();
        
        }
    }
}
