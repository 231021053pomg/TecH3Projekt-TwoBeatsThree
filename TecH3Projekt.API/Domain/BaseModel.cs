using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;//

namespace TecH3Projekt.API.Domain
{
    public class BaseModel
    {
        [Key]  //Key because its ID
        public int Id { get; set; } 

        [JsonIgnore]  //can't be sent to client.
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAt { get; set; }//? means can be null.

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}
