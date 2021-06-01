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
    }
}
