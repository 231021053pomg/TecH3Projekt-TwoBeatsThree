using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Picture
    {
        public string src { get; set; }

        [ForeignKey("Product.Id")]
        public int ProductId { get; set; }
    }
}
