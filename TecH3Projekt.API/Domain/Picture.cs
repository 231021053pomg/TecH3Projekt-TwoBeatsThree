using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Picture : BaseModel
    {
        [Required]
        public string Src { get; set; }

        //public string Name { get; set; } //For naming pics.

        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }
    }
}
