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
        public int TypeId { get; set; } //ForeignKey to Type

        public Type Type { get; set; } //Property of type

        [Required]
        public string ProductName { get; set; }

        [Required]
        public double Price { get; set; }

        public string Description { get; set; }



        //List creation for each 1-to-M relation.
        //Picture
        public Product()//ctor needed for get of list.
                        //Creates an empty list of Pictures so it can not be null
        {
            Pictures = new List<Picture>();
        }
        public List<Picture> Pictures { get; set; }//List is used for 1-to-M relation.
                                                   //1 product can have many pictures
    }
}
