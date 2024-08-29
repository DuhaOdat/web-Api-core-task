using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ObjectiveC;
using taskTwoAPICore.DTOfolder;
using taskTwoAPICore.Models;

namespace taskTwoAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly MyDbContext _db;
        
        public CartItemsController(MyDbContext db)
        { 
            _db = db;
        }
        [HttpGet("GetAllCartItems")]
        public IActionResult GetAllCartItems()
        {
            var cartITems = _db.CartItems.Select(x =>

           new CartItemResponseDTO
           {
               CartId = x.CartId,
               CartItemId = x.CartItemId,
               Quantity = x.Quantity,
               Product = new productDTO
               {
                   ProductId = x.Product.Id,
                   ProductName = x.Product.ProductName,
                   Price = x.Product.Price,

               }
           }

           );

            return Ok(cartITems);
        }


        [HttpPost]
        public IActionResult AddToCart([FromBody] AddCartRequest addCartRequest)
        {
            var data = new CartItem
            {
                CartId = addCartRequest.CartId,
                ProductId = addCartRequest.ProductId,
                Quantity = addCartRequest.Quantity,

            };
            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok();




        }
    }
}
