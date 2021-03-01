using System.Collections.Generic;

namespace LOR.Pizzeria.Domain.Entities
{
    public class Store
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<StorePizza> Pizzas { get; set; } = new List<StorePizza>();
    }
}