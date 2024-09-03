using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.DTOfolder;
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
            var category = _db.Categories.FirstOrDefault(c => c.CategoryName == name);

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

            var deletedProduct=_db.Products.Where(p=>p.CategoryId == id).ToList();
            _db.RemoveRange(deletedProduct);
            _db.SaveChanges();

            var deleteCategory = _db.Categories.FirstOrDefault(x => x.Id == id);

                _db.Categories.Remove(deleteCategory);
                _db.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public IActionResult createCategory([FromForm] categoryRequestDTO category)

        {
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, category.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(stream);
            }

            var c = new Category
            {
                CategoryName = category.CategoryName,
                CategoryImage = category.CategoryImage.FileName,
            };

            _db.Categories.Add(c);
            _db.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromForm] categoryRequestDTO category)
        {
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            var imageFile = Path.Combine(ImagesFolder, category.CategoryImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                category.CategoryImage.CopyToAsync(stream);
            }
            var c = _db.Categories.FirstOrDefault(l => l.Id == id);
            c.CategoryName = category.CategoryName;
            c.CategoryImage = category.CategoryImage.FileName;
            //c.CategoryImage = category.CategoryImage.FileName ?? c.CategoryImage;

            _db.Categories.Update(c);
            _db.SaveChanges();
            return Ok();

        }

        //[HttpGet("calculater")]
        //public string calculater(string input  )
        //{
        //    string[] x = input.Split(' ');

        //    int num1 = Convert.ToInt32(x[0]);
        //    int num2= Convert.ToInt32(x[2]);
        //    if (x[1] == "+")
        //    {
        //        return (num1 + num2).ToString();
        //    }
        //    else if (x[1] == "-")
        //    {
        //        return (num1 - num2).ToString();
        //    }
        //    else if (x[1] == "*")
        //    {
        //        return (num1 * num2).ToString();
        //    }
        //    else if (x[1] == "/")
        //    {
        //        return (num1 / num2).ToString();
        //    }
        //    else {
        //        return "invalid opration";
        //     }         
        //}


        [HttpGet("calc2")]
        public IActionResult Calc(string input)
        {
            var x = input.Split(' ');
            var num1 = Convert.ToDouble(x[0]);
            var op = x[1];
            var num2 = Convert.ToDouble(x[2]);

            double result = 0;
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num1 == 0)
                    {
                        return BadRequest("cant division by zero");
                    }
                    else
                    {
                        result = num1 / num2;
                        break;
                    }
            }
            return Ok();

        }


        [HttpGet("math")]
        public bool Math(int num1, int num2)
        {
            if (num1 + num2 == 30 || num1 == 30 || num2 == 30)
            {
                return true;
            
            }
            else
            {
                return false;

            }
            
        
        }

        [HttpGet("check")]

        public IActionResult checker(int num)
        {
            if (num % 3 == 0 || num % 7 == 0)
                return Ok("true");

            else { 
                return Ok(false);
            
            }

        }

        //[HttpGet("getnumberOddOccurring")]
        //public IActionResult checkOddrepeat([FromQuery] int[] num)

        //{
        //    var op = num.GroupBy(a => a).Where(g => g.Count() % 2 != 0).Select(g => g.Key).ToList();

        //    return Ok(op);
        //}
        [HttpPost("getnumberOddOccurring")]
        public IActionResult checkOddrepeat([FromBody] List<int> num)

        {
            var op=  num.GroupBy(a=>a).Where(g=>g.Count() % 2 !=0).Select(g=>g.Key).ToList();

            return Ok(op);
        }


    }
}
