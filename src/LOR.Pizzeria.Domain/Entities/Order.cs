using System.Collections.Generic;

namespace LOR.Pizzeria.Domain.Entities
{
    public class Order
    {
        public string Id { get; set; }
        public string Customer { get; set; }
        public Store Store { get; set; }
        public ICollection<OrderedPizza> Pizzas { get; } = new List<OrderedPizza>();
    }
}