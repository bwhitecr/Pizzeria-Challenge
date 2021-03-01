using System;

using LOR.Pizzeria.Application;
using LOR.Pizzeria.Application.Interfaces;

namespace LOR.Pizzeria.Infrastructure
{
    public class SystemConsoleAdapter : IPizzaSelector, IConsoleWriter
    {
        public string GetStoreName() => Console.ReadLine();
        public string GetPizzaName() => Console.ReadLine();

        public void WriteLine(string text) => Console.WriteLine(text);
    }
}