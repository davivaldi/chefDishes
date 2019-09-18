using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}
        [Required(ErrorMessage="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Last Name is required")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB {get; set;}

        public string CreatedAt { get; set;}
        public string UpdatedAt {get; set;}

        public List<Dish> CreatedDishes {get;set;}

    }
}