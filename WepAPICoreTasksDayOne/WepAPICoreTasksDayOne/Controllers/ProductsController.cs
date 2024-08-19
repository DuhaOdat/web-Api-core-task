using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WepAPICoreTasksDayOne.Models;

namespace WepAPICoreTasksDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDbContext _db;
        public ProductsController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var products = _db.Products.Where(p=>p.Id==id).FirstOrDefault();
            return Ok(products);
        }
    }
}
