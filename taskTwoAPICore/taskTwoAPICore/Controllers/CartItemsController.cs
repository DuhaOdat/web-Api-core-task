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


        [HttpDelete("{id}")]
        public IActionResult deleteCartItem(int id)
        {

            var cartItem = _db.CartItems.FirstOrDefault(l => l.CartItemId == id);

            _db.CartItems.Remove(cartItem);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult cartItemPut(int id, [FromBody] cartItemPutDTO cartItem)
        {
            var cart = _db.CartItems.FirstOrDefault(l => l.CartItemId == id);
            cart.Quantity = cartItem.Quantity;
            _db.CartItems.Update(cart);
            _db.SaveChanges();
            return Ok();
        }
    }
}
