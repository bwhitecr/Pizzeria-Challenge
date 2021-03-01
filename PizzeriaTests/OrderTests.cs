using System;
using System.IO;

using FluentAssertions;

using Microsoft.VisualStudio.TestPlatform.TestHost;

using NUnit.Framework;

namespace PizzeriaTests
{
    public class OrderTests
    {
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

            LOR.Pizzeria.Program.Main(Array.Empty<string>());

            var receipt = "Total price: " + price;

            output.ToString().Should().Contain(receipt);
        }
    }
}