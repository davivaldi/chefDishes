using Microsoft.EntityFrameworkCore;



namespace ChefDishes.Models
{
    public class ChefDishesContext: DbContext
    {
        public ChefDishesContext(DbContextOptions options) : base(options) { }
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dish {get;set;}
        
    }
}