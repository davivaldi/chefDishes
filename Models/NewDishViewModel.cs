using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefDishes.Models;


namespace ChefDishes.Models
{
    public class NewDishViewModel
    {
        public List<Chef> Chefs{get; set;}
        public Dish Dish {get; set;}
    }
}