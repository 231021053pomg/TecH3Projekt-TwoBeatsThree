using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//
using System.ComponentModel.DataAnnotations.Schema;//
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class OrderItem : BaseModel
    {
        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }

        [ForeignKey("Order.Id")]
        public int OrderId { get; set; }

        public int Quantity { get; set; }
        [Required]
        public int SinglePrice { get; set; }
    }
}
