using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//
using System.ComponentModel.DataAnnotations.Schema;//
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Order : BaseModel
    {
        [ForeignKey("LogIn.Id")]
        public int LogInId { get; set; }

        [Required]
        public DateTime OrderMade { get; set; }

        //public bool Status { get; set; }//EXTRA

        //List creation for each 1-to-M relation.
        //OrderItem
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public List<OrderItem> OrderItems { get; set; }

        public LogIn LogIn { get; set; }
    }
}
