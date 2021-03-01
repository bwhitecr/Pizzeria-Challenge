using System.Collections.Generic;
using System.Text;

namespace LOR.Pizzeria.Domain.Entities
{
    public class Pizza
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Ingredients { get; set; } = new List<string>();
        public decimal BasePrice { get; set; }

        public string Prepare()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Preparing " + Name + "...");
            builder.Append("Adding ");
            foreach (var i in Ingredients)
            {
                builder.Append(i + " ");
            }
            builder.AppendLine();
            return builder.ToString();
        }

        public string Bake()
        {
            if (Name == "Margherita")
                return "Baking pizza for 15 minutes at 200 degrees...";
            else
            {
                return "Baking pizza for 30 minutes at 200 degrees...";
            }
        }

        public string Cut()
        {
            if (Name == "Florenza")
                return "Cutting pizza into 6 slices with a special knife...";
            
            return "Cutting pizza into 8 slices...";
        }

        public string Box()
        {
            return "Putting pizza into a nice box...";
        }


        public string PrintReceipt()
        {
            return "Total price: " + BasePrice;
        }
    }
}