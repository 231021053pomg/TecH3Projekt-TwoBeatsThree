﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//
using System.Linq;
using System.Threading.Tasks;

namespace TecH3Projekt.API.Domain
{
    public class Property : BaseModel
    {
        [Required]
        public string PropertyName { get; set; }
    }
}
