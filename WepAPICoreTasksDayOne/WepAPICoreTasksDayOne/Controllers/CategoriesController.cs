using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WepAPICoreTasksDayOne.Models;

namespace WepAPICoreTasksDayOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext db)
        { 
            _db = db;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            var categories = _db.Categories.ToList();
        
           return Ok(categories);
        }


        [HttpGet("id")]
        public IActionResult Get(int id)
        { 
           var category = _db.Categories.Where(c=>c.Id==id).FirstOrDefault();
            return Ok(category);
        }
    }
}
