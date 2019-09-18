using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;


namespace ChefDishes.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Chef { get; set; }
        [Required]
        [Range(1,5)]
        public int Tastiness { get; set; }
        [Required]
        [Range(1,3000, ErrorMessage = "Must be at least 1 calorie")]
        
        public int Calories { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Chef Creator {get;set;}
    }

}