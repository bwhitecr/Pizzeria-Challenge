using System.Linq;

namespace LOR.Pizzeria.Domain.Entities
{
    public class StorePizza
    {
        public string Id { get; set; }
        public Store Store { get; set; }
        public Recipe Recipe { get; set; }
        public decimal BasePrice { get; set; }

        public override string ToString()
        {
            return Recipe.Name + " - " +
                   Recipe.Toppings
                       .Aggregate(string.Empty, (x, t) => string.IsNullOrWhiteSpace(x) ? t.Name : x + ", " + t.Name)
                   + " - " +
                   BasePrice.ToString();
        }
    }
}