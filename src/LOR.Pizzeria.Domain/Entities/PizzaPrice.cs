namespace LOR.Pizzeria.Domain.Entities
{
    public class PizzaPrice
    {
        public Store Store { get; set; }
        public Pizza Pizza { get; set; }
        public decimal Price { get; set; }
    }
}