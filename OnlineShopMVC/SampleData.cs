using System.Linq;
using OnlineShopMVC.Models;

namespace OnlineShopMVC
{
    public class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product("Chicken", 3884, "Voonyx", "In felis", 378),
                    new Product("Kippers", 7499, "Skipfire", "Mi", 207),
                    new Product("Pork", 2191, "Tagtune", "Nisl", 186),
                    new Product("Soup", 6631, "Yodoo", "Scelerisque quam", 128),
                    new Product("Sweater", 8836, "Skinix", "Quis", 496),
                    new Product("Trueblue", 4009, "Skipfire", "Nunc", 338),
                    new Product("Truffle Cups", 1740, "Tagtune", "Aenean auctor", 441),
                    new Product("Quail", 9223, "Voonyx", "Eget", 111),
                    new Product("Seedlings", 6154, "Skipfire", "Quisque", 302),
                    new Product("Lettuce", 2239, "Tagtune", "Diam nam", 132)
                );
                context.SaveChanges();
            }
        }
    }
}
