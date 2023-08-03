using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Models
{
    public class MenuItem
    {
        [Key]
        public int Id {get; set;}

        public string Image{get; set;}

        [Required]
        public string Name{get; set;}



        public string Description {get; set;}

       

        public double Price {get; set;}

        public int FoodTypeId {get; set;} 

        // [ForeignKey("FoodTypeId")]
        public FoodType FoodType{get; set;}

        public int CategoryModelId {get; set;}

        public CategoryModel CategoryModel {get; set;}
    }
}