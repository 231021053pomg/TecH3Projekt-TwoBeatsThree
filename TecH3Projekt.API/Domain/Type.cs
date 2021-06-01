using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Type : BaseModel
    {
       [Required]
        public string TypeName { get; set; }
    }
}
