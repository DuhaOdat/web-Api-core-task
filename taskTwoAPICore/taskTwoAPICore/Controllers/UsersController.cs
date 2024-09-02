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
            if (id <= 0) return BadRequest();

            var deletedCart = _db.Carts.FirstOrDefault(c => c.UserId == id);
            _db.RemoveRange(deletedCart);
            _db.SaveChanges();
            var deletedUsers = _db.Users.FirstOrDefault(u => u.UserId == id);

            _db.Users.Remove(deletedUsers);
            _db.SaveChanges();
            return NoContent();


        }

        [HttpPost]
        public IActionResult AddUsers([FromForm] UsersRequestDTO user)
        {
            var u = new User
            {
                Email = user.Email,
                Password = user.Password,
                

            };
            _db.Users.Add(u);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsers(int id, [FromForm] UsersRequestDTO user)
        {
            var users = _db.Users.FirstOrDefault(u => u.UserId == id);
          
           
            user.Email = users.Email;
            user.Password = users.Password;
            _db.Users.Update(users);
            _db.SaveChanges();
            return Ok();

        }

        [HttpPost("Register")]
        public IActionResult addNewUser([FromForm] UsersRequestDTO userDTO)
        {

            byte[] hash;
            byte[] salt;
            PasswordHasher.CreatePasswordHash(userDTO.Password, out hash, out salt);
            User user = new User
            {
                Email = userDTO.Email,
                Password = userDTO.Password,
                PasswordHash = hash,
                PasswordSalt = salt 

            };
          
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        [HttpPost("Login")]
        public IActionResult Login([FromForm] UsersRequestDTO userDTO)
        {
           var user = _db.Users.FirstOrDefault(a=>a.Email == userDTO.Email);
            if (user==null || !PasswordHasher.VerifyPasswordHash(userDTO.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid");
            }
            return Ok("Logged in successfully");
        }




    } 
}
