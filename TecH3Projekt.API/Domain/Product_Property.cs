using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Product_Property
    {
        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }

        [ForeignKey("Property.Id")]
        public int PropertyId { get; set; }
    }
}
