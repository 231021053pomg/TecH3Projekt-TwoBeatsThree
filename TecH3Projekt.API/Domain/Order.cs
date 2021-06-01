using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Order : BaseModel
    {
        [ForeignKey("LogIn.Id")]
        public int LogInId { get; set; }
        public DateTime DateMade { get; set; }//Confirm???

        public bool Status { get; set; }//EXTRA
    }
}
