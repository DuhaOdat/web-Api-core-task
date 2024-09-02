using System.ComponentModel.DataAnnotations;

namespace taskTwoAPICore.DTOfolder
{
    public class UsersRequestDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }

        

        
    }
}
