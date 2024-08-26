using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskTwoAPICore.DTOfolder;
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

        [HttpPost]
        public IActionResult AddUsers([FromForm] UsersRequestDTO user)
        {
            var u = new User
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,

            };
            _db.Users.Add(u);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsers( int id,[FromForm] UsersRequestDTO user)
        {
            var users = _db.Users.FirstOrDefault(u=>u.UserId == id);
            user.Username = users.Username;
            user.Password = users.Password;
            user.Email = users.Email;

            _db.Users.Update(users);
            _db.SaveChanges() ;
            return Ok();

        }



    } 
}
