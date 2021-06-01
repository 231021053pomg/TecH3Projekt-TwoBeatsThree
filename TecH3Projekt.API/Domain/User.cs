using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class User : BaseModel
    {
        [ForeignKey("LogIn.Id")]
        public int LogInId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int PostNr { get; set;}
        public string City { get; set; }

    }
}
