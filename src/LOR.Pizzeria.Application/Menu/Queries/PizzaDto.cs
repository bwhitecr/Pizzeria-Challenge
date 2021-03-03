using System.Collections.Generic;

namespace LOR.Pizzeria.Application.Menu.Queries
{
    /// <summary>
    /// Represents pizza information to display to the user.
    /// </summary>
    public class PizzaDto
    {
        /// <summary>
        /// Identifier used for ordering the pizza.
        /// </summary>
        public string PizzaId { get; set; } = "";
        
        /// <summary>
        /// The name of the pizza.
        /// </summary>
        public string PizzaName { get; set; } = "";
        
        /// <summary>
        /// A list of the toppings.
        /// </summary>
        public List<string> Toppings { get; set; } = new ();
        
        /// <summary>
        /// The price of the pizza in the selected store.
        /// </summary>
        public decimal Price { get; set; }
    }
}