using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        [Display(Name ="FirstName")]
        [MinLength(2)]
        public string FirstName {get;set;}
        [Required]
        [Display(Name ="LastName")]
        [MinLength(2)]
        public string LastName {get;set;}
        [Required]
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth {get;set;}
        public List<Dish> Dishes {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}