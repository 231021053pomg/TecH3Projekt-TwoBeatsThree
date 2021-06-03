using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class LogIn : BaseModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
        public int MyProperty { get; set; }

        //For include in LogInRepository.
        public LogIn()
        {
            UserProfile = new List<User>();
        }
        public List<User> UserProfile { get; set; }
        //public int UserId { get; set; }
    }
}
