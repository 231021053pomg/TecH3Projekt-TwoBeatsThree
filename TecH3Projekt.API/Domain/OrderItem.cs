using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class OrderItem : BaseModel
    {
        [ForeignKey("Order.Id")]
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        public int SinglePrice { get; set; }
    }
}
