using System;
using System.Collections.Generic;
using System.IO;

using FluentAssertions;

using LOR.Pizzeria.Application;
using LOR.Pizzeria.Application.Interfaces;
using LOR.Pizzeria.Application.Ordering;
using LOR.Pizzeria.Infrastructure.Persistence;

using Moq.AutoMock;

using NUnit.Framework;

namespace PizzeriaTests
{
    public class OrderTests
    {
        private class FakeConsoleWriter : IConsoleWriter
        {
            private readonly List<string> _output = new ();
            
            public void WriteLine(string text)
            {
                _output.Add(text);
            }

            public IReadOnlyList<string> Output => _output;
        }
        
        [TestCase("Brisbane", "Capriciosa", 20)]
        [TestCase("Brisbane", "Florenza", 21)]
        [TestCase("Brisbane", "Margherita", 22)]
        [TestCase("Sydney", "Capriciosa", 30)]
        [TestCase("Sydney", "Inferno", 31)]
        public void Test1(string store, string pizza, decimal price)
        {
            var output = new StringWriter();
            Console.SetOut(output);
            
            var input = new StringReader(store+Environment.NewLine+pizza+Environment.NewLine);
            Console.SetIn(input);

            var mocker = new AutoMocker();
            mocker.Setup<IPizzaSelector, string>(x => x.GetStoreName())
                .Returns(store);
            mocker.Setup<IPizzaSelector, string>(x => x.GetPizzaName())
                .Returns(pizza);

            var writer = new FakeConsoleWriter();

            mocker.Use<IConsoleWriter>(writer);
            mocker.Use<IApplicationDbContext>(new DefaultDbContext());

            var order = mocker.Get<PizzaOrder>();
            
            order!.PlaceOrder();

            var receipt = "Total price: " + price;

            writer.Output.Should().NotBeEmpty();
            writer.Output.Should().Contain(receipt);
        }
    }
}