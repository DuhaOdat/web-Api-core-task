using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.Models;

namespace taskTwoAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public UsersController(MyDbContext db)
        {

            _db = db;

        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _db.Users.ToList();
            return Ok(users);
        }

        [Route("GetUserById{id:int}")]
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            if (id == 0)
                return BadRequest();

            var users = _db.Users.FirstOrDefault(u => u.UserId == id);
            return Ok(users);
        }
        [Route("GetUserByName{name}")]
        [HttpGet]
        public IActionResult GetUserByName(string name)
        {
            if (name == null)
                return BadRequest();
            var users = _db.Users.FirstOrDefault(u => u.Username == name);
            return Ok(users);
        }

        [Route("DeleteUserById{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            if (id<=0) return BadRequest();
            var users = _db.Users.FirstOrDefault(u=>u.UserId == id);
            if (users==null)
                return NotFound();
            else
            {
                _db.Users.Remove(users);
                _db.SaveChanges();
                return NoContent();
            }

        }


    } 
}
