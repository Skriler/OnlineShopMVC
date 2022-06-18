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
                    new Product("Pork", 2191, "Gabtype", "Nisl", 186),
                    new Product("Soup", 6631, "Yodoo", "Scelerisque quam", 128),
                    new Product("Sweater", 8836, "Gabtype", "Quis", 496),
                    new Product("Trueblue", 4009, "Skipfire", "Nunc", 338),
                    new Product("Truffle Cups", 1740, "Tagtune", "Aenean auctor", 441),
                    new Product("Quail", 9223, "Voonyx", "Gabtype", 111),
                    new Product("Seedlings", 6154, "Skipfire", "Quisque", 302),
                    new Product("Lettuce", 2239, "Tagtune", "Nunc", 132),
                    new Product("Longos", 5309, "Kare", "Nunc", 849),
                    new Product("Gatorade", 2142, "Kare", "Ante", 352),
                    new Product("Juice", 7854, "Rhybox", "Pede", 627),
                    new Product("Prince", 5003, "Gabtype", "Nunc", 72),
                    new Product("Cheese", 5855, "Kare", "Quis", 61),
                    new Product("Stock", 402, "Skipfire", "Nunc", 334),
                    new Product("Beef", 567, "Browsedrive", "Quis", 531),
                    new Product("Cleaner", 2697, "Gabtype", "Quis", 289),
                    new Product("Onion", 6028, "Browsedrive", "Quisque", 452),
                    new Product("Cream", 3554, "Tagtune", "Diam nam", 617),               
                    new Product("Spaghetti", 8231, "Gabtype", "Nunc", 637),
                    new Product("Grenadine", 2375, "Browsedrive", "Quis", 202),
                    new Product("Icecream", 5042, "Kare", "Nunc", 729),
                    new Product("Wine", 6956, "Gabtype", "Scelerisque quam", 207),
                    new Product("Strawberry", 781, "Kare", "Quis", 153),
                    new Product("Beer", 8911, "Browsedrive", "Nunc", 699),
                    new Product("Pomegranates", 7691, "Gabtype", "Quis", 180),
                    new Product("Towels", 9943, "Browsedrive", "Eget", 252),
                    new Product("Wyndham", 4298, "Kare", "Nunc", 971),
                    new Product("Crab", 8180, "Voolith", "Nunc", 990)
                );
                context.SaveChanges();
            }
        }
    }
}
