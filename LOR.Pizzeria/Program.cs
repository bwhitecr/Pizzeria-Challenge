using LOR.Pizzeria.Application.Ordering;
using LOR.Pizzeria.Infrastructure;

namespace LOR.Pizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var consoleAdapter = new SystemConsoleAdapter();
            var order = new PizzaOrder(consoleAdapter, consoleAdapter);
            order.PlaceOrder();
        }
    }
}
