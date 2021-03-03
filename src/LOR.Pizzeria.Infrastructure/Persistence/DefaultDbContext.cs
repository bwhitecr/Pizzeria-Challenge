using System;
using System.Collections.Generic;
using System.Linq;

using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Domain.Entities;

namespace LOR.Pizzeria.Infrastructure.Persistence
{
    public class DefaultDbContext: IApplicationDbContext
    {
        private static readonly List<Recipe> _recipes;
        private static readonly List<Store> _stores;

        private static readonly List<Topping> _toppings = new List<Topping>
        {
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "mushrooms" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "cheese" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "ham" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "olives" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "pastrami" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "onion" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "garlic" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "oregano" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "chili peppers" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "chicken" 
            },
            new Topping
            {
                Id = Guid.NewGuid().ToString(),
                Name = "mozzarella" 
            },
        };

        static DefaultDbContext()
        {
            _recipes = SetupRecipes();
            _stores = SetupStores();
        }

        static List<Recipe> SetupRecipes()
        {
            return new List<Recipe>
            {
                new Recipe
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Capriciosa",
                    Toppings = GetToppings("mushrooms", "cheese", "ham", "mozzarella"),
                    PreparationInstructions = new List<string>
                    {
                        "Baking pizza for 30 minutes at 200 degrees...",
                        "Cutting pizza into 8 slices...",
                        "Putting pizza into a nice box..."
                    }
                },
                new Recipe
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Florenza",
                    Toppings = GetToppings("olives", "pastrami", "mozzarella", "onion"),
                    PreparationInstructions = new List<string>
                    {
                        "Baking pizza for 30 minutes at 200 degrees...",
                        "Cutting pizza into 6 slices with a special knife...",
                        "Putting pizza into a nice box..."
                    }
                },
                new Recipe
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Margherita",
                    Toppings = GetToppings("mozzarella", "onion", "garlic", "oregano"),
                    PreparationInstructions = new List<string>
                    {
                        "Baking pizza for 15 minutes at 200 degrees...",
                        "Cutting pizza into 8 slices...",
                        "Putting pizza into a nice box..."
                    }
                },
                new Recipe
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Inferno",
                    Toppings = GetToppings("chili peppers", "mozzarella", "chicken", "cheese"),
                    PreparationInstructions = new List<string>
                    {
                        "Baking pizza for 30 minutes at 200 degrees...",
                        "Cutting pizza into 8 slices...",
                        "Putting pizza into a nice box..."
                    }
                }
            };
            
            static List<Topping> GetToppings(params string[] names)
                => _toppings.Join(names, x => x.Name, n => n, (x, _) => x)
                    .OrderBy(x => x.Name)
                    .ToList();
        }

        static List<Store> SetupStores()
        {
            return new List<Store>
            {
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Brisbane",
                    Pizzas = new List<StorePizza>
                    {
                        Pizza("Capriciosa", 20m),
                        Pizza("Florenza", 21m),
                        Pizza("Margherita", 22m)
                    }
                },
                new Store
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Sydney",
                    Pizzas = new List<StorePizza>
                    {
                        Pizza("Capriciosa", 30m),
                        Pizza("Inferno", 31m)
                    }
                }
            };

            StorePizza Pizza(string name, decimal price)
                => _recipes.Where(x => x.Name == name)
                    .Select(x => new StorePizza
                    {
                        Id = Guid.NewGuid().ToString(),
                        BasePrice = price,
                        Recipe = x
                    }).First();
        }

        public IQueryable<Store> Stores => _stores.AsQueryable();
        public IQueryable<Recipe> Recipes => _recipes.AsQueryable();

    }
}