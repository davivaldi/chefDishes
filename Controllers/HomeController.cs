using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefDishesContext dbContext;
     
        // here we can "inject" our context service into the constructor
        public HomeController(ChefDishesContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.Chefs.OrderByDescending(des=> des.CreatedAt).ToList();
            foreach ( Chef item in AllChefs )
            {
                System.Console.WriteLine(AllChefs);
            }
            
            return View(AllChefs);
        }

        [HttpGet("dishes")]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.Dish
            .Include(Dish => Dish.Creator)
            .ToList();
         return View(AllDishes);
        }

        [HttpGet("new/chef")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpGet("new/dish")]
        public IActionResult NewDish()
        {
            NewDishViewModel model = new NewDishViewModel()
            {
                Chefs = dbContext.Chefs.ToList()
            };
            return View(model);
        }

        [HttpPost("Create/Dish")]
        public IActionResult CreateDish(NewDishViewModel newModel)
        {
            Console.WriteLine(newModel);
            Console.WriteLine(newModel.Dish.Chef);
            Console.WriteLine(newModel.Dish.Name);
            Console.WriteLine(newModel.Dish.Calories);
            Console.WriteLine(newModel.Dish.Tastiness);
            Console.WriteLine(newModel.Dish.Description);

            if(ModelState.IsValid)
            {
                dbContext.Add(newModel.Dish);
                dbContext.SaveChanges();
                return RedirectToAction("dishes");
            }
            else
            {
                return View("NewDish");
            }
        }

        [HttpPost("Create/Chef")]
        public IActionResult CreateChef(Chef newChef)
        {
            Console.WriteLine(newChef);
            Console.WriteLine(newChef.FirstName);
            Console.WriteLine(newChef.LastName);
            Console.WriteLine(newChef.DOB);
 

            if(ModelState.IsValid)
            {
                dbContext.Add(newChef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("NewChef");
            }
        }











        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
