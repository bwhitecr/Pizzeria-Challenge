using System;
using System.Linq;
using System.Text;

using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Domain.Entities;

#nullable enable

namespace LOR.Pizzeria.Application.Ordering
{
    public class PizzaOrder
    {
        private readonly IPizzaSelector _reader;
        private readonly IConsoleWriter _writer;
        private readonly IApplicationDbContext _dbContext;

        public PizzaOrder(IPizzaSelector reader, IConsoleWriter writer, IApplicationDbContext dbContext)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void PlaceOrder()
        {
            var storeLocations = _dbContext.Stores
                .Select(x => x.Name)
                .Aggregate(string.Empty, (a, b) => a == string.Empty ? b : a + " OR " + b);
            _writer.WriteLine($"Welcome to LOR Pizzeria! Please select the store location: {storeLocations}");
            var storeName = _reader.GetStoreName();

            var store = _dbContext.Stores.First(x => x.Name == storeName);

            PrintStoreMenu(store);
            
            _writer.WriteLine("What can I get you?");

            var pizzaType = _reader.GetPizzaName();

            var pizza = store.Pizzas.First(x => x.Recipe.Name == pizzaType);
            _writer.WriteLine(PreparePizza(pizza.Recipe));
            
            _writer.WriteLine(PrintReceipt(pizza));

            _writer.WriteLine("\nYour pizza is ready!");
        }

        private void PrintStoreMenu(Store store)
        {
            _writer.WriteLine("MENU");

            foreach (var pizza in store.Pizzas)
            {
                _writer.WriteLine(pizza.ToString());
            }
        }

        private string PreparePizza(Recipe recipe)
        {
            var builder = new StringBuilder();
            builder.AppendLine("Preparing " + recipe.Name + "...");
            builder.Append("Adding ");
            foreach (var i in recipe.Toppings)
            {
                builder.Append(i + " ");
            }
            builder.AppendLine();
            foreach (var instruction in recipe.PreparationInstructions)
            {
                builder.AppendLine(instruction);
            }
            return builder.ToString();
        }

        private string PrintReceipt(StorePizza pizza)
        {
            return "Total price: " + pizza.BasePrice;
        }
    }
}