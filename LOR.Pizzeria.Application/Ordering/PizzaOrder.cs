using System;
using System.Collections.Generic;

using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Domain;

#nullable enable

namespace LOR.Pizzeria.Application.Ordering
{
    public class PizzaOrder
    {
        private readonly IPizzaSelector _reader;
        private readonly IConsoleWriter _writer;

        public PizzaOrder(IPizzaSelector reader, IConsoleWriter writer)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public void PlaceOrder()
        {
            _writer.WriteLine("Welcome to LOR Pizzeria! Please select the store location: Brisbane OR Sydney");
            var Store = _reader.GetStoreName();

            _writer.WriteLine("MENU");
            if (Store == "Brisbane")
            {
                _writer.WriteLine("Capriciosa - mushrooms, cheese, ham, mozarella - 20 AUD");
                _writer.WriteLine("Florenza - olives, pastrami, mozarella, onion - 21 AUD");
                _writer.WriteLine("Margherita - mozarella, onion, garlic, oregano - 22 AUD");
            }
            else if (Store == "Sydney")
            {
                _writer.WriteLine("Capriciosa - mushrooms, cheese, ham, mozarella - 30 AUD");
                _writer.WriteLine("Inferno - chili peppers, mozzarella, chicken, cheese - 31 AUD");
            }



            _writer.WriteLine("What can I get you?");

            var pizzaType = _reader.GetPizzaName();


            var pizza = new Pizza();
            switch(pizzaType)
            {
                case "Capriciosa":
                    var capriciosaPrice = 0;
                    if (Store == "Brisbane") capriciosaPrice = 20;
                    if (Store == "Sydney") capriciosaPrice = 30;

                    pizza = new Pizza(){ Name = "Capriciosa", Ingredients = new List<string>{ "mushrooms", "cheese", "ham", "mozarella" }, BasePrice = capriciosaPrice};
                    break;
                case "Florenza":
                    pizza = new Pizza() { Name = "Florenza", Ingredients = new List<string> { "olives", "pastrami", "mozarella", "onion" }, BasePrice = 21};
                    break;
                case "Margherita":
                    pizza = new Pizza() { Name = "Margherita", Ingredients = new List<string> { "mozarella", "onion", "garlic", "oregano" }, BasePrice = 22};
                    break;
                case "Inferno":
                    pizza = new Pizza() { Name = "Inferno", Ingredients = new List<string> { "chili peppers", "mozzarella", "chicken", "cheese" }, BasePrice = 31};
                    break;
                default:
                    break;
            }
            _writer.WriteLine(pizza.Prepare());
            _writer.WriteLine(pizza.Bake());
            _writer.WriteLine(pizza.Cut());
            _writer.WriteLine(pizza.Box());
            _writer.WriteLine(pizza.PrintReceipt());

            _writer.WriteLine("\nYour pizza is ready!");
        }
    }
}