using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.DTOfolder;
using taskTwoAPICore.Models;

namespace taskTwoAPICore.Controllers
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
        public IActionResult GetAllProducts()
        {
            var products = _db.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id:int:max(10)}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0)
                return BadRequest();

            var product = _db.Products.Where(p => p.Id == id);
            return Ok(product);
        }

        [HttpGet("productsByCategoryId/{categoryId}")]
        public IActionResult getProductsById(int categoryId) 
        { 
            var products=_db.Products.Where(x=>x.CategoryId == categoryId).ToList();
            return Ok(products);
        
        }

        [HttpGet("descendingPrice")]
        public IActionResult descendingPrice() 
        {
            var products=_db.Products.OrderByDescending(x => x.Price).ToList();

            return Ok(products);
        }

        [HttpGet("AcendingPrice")]
        public IActionResult AcendingPrice()
        {
            var products = _db.Products.OrderBy(x => x.Price).ToList();

            return Ok(products);
        }

        [HttpGet("{name}")]
        public IActionResult GetProductName(string name)
        {
            var products = _db.Products.Where(p => p.ProductName == name).FirstOrDefault();

            if (products != null)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            if (id <= 0)
                return BadRequest();

            var products = _db.Products.Where(p => p.Id == id).FirstOrDefault();
            if (products == null)
                return NotFound();
            _db.Products.Remove(products);
            _db.SaveChanges();
            return Ok();


        }

        [HttpPost]
        public IActionResult CreateProduct([FromForm] productRequestDTO product)

        {

            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }

            var p = new Product
            {
                ProductName = product.ProductName,
                ProductImage = product.ProductImage.FileName,
            };

            _db.Products.Add(p);
            _db.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromForm] productRequestDTO product)
        {
            var ImagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(ImagesFolder))
            {
                Directory.CreateDirectory(ImagesFolder);
            }
            var imageFile = Path.Combine(ImagesFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }
            var p = _db.Products.FirstOrDefault(l => l.Id == id);
            p.ProductName = product.ProductName;
            p.ProductImage = product.ProductImage.FileName;
          

            _db.Products.Update(p);
            _db.SaveChanges();
            return Ok();

        }

    }


}
