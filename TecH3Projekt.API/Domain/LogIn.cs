using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class LogIn : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int MyProperty { get; set; }
        
        //For include in LogInRepository.
        public List<User> UserProfile { get; set; }
        public int UserId { get; set; }
    }
}
