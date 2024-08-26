using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.Models;

namespace taskTwoAPICore.Controllers
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
        [Route("AllCategories")]
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categories = _db.Categories.ToList();

            return Ok(categories);
        }

        [Route("GetCategoryById/{id:int:min(5)}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest();
            var category = _db.Categories.Where(c => c.Id == id).FirstOrDefault();
            return Ok(category);
        }

        [Route("GetCategoryByName/{name:alpha}")]
        [HttpGet]
        public IActionResult GetCategoryByName(string name)
        {
            var category=_db.Categories.FirstOrDefault(c=>c.CategoryName == name);

            if (category != null)
            {
               return Ok(category);

            }
          
            else
            {
                return NotFound();
            }
        }

        [Route("DeleteCategory/{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null) 
            {
                return NotFound();
            }
            else
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return Ok();
            }
        }
    }
    }
