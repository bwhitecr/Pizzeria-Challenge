using LOR.Pizzeria.Application.Ordering;
using LOR.Pizzeria.Infrastructure;
using LOR.Pizzeria.Infrastructure.Persistence;

namespace LOR.Pizzeria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var consoleAdapter = new SystemConsoleAdapter();
            var dbContext = new DefaultDbContext();
            var order = new PizzaOrder(consoleAdapter, consoleAdapter, dbContext);
            order.PlaceOrder();
        }
    }
}
