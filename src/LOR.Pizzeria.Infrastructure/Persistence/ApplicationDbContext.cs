using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace LOR.Pizzeria.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        
        public DbSet<Store> Stores { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedPizza> OrderedPizzas { get; set; }
    }
}