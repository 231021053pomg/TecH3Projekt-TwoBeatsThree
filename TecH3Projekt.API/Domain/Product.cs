using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Product : BaseModel
    {
        [ForeignKey("Type.Id")]
        public int TypeId { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
