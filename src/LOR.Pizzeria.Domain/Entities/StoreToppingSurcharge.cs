namespace LOR.Pizzeria.Domain.Entities
{
    public class StoreToppingSurcharge
    {
        public string Id { get; set; } 
        public Store Store { get; set; }
        public decimal Surcharge { get; set; }
    }
}