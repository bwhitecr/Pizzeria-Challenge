using System.Collections.Generic;

namespace LOR.Pizzeria.Domain.Entities
{
    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Topping> Toppings { get; set; } = new List<Topping>();
        public ICollection<string> PreparationInstructions { get; set; } = new List<string>();
    }
}