using System;
using System.ComponentModel.DataAnnotations;
namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        [Display(Name ="Name")]
        [MinLength(2)]
        public string Name {get;set;}
        [Required]
        [Display(Name ="Tastiness")]
        [Range(1,5)]
        public int Tastiness {get;set;}
        [Required]
        [Display(Name ="Calorie Count")]
        [Range(1,5000)]
        public int Calories {get;set;}
        public string Description {get;set;}
        [Required]
        public int ChefId {get;set;}
        public Chef Chef {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}