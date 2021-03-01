using System.Collections.Generic;

namespace LOR.Pizzeria.Domain.Entities
{
    public class OrderedPizza
    {
        public string Id { get; set; }
        public Recipe Recipe { get; set; }
        public ICollection<Topping> ExtraToppings { get; } = new List<Topping>();
        public Order Order { get; set; }
    }
}