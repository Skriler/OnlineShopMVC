namespace OnlineShopMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Producer { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }

        public Product(string title, int price, string producer, string type, int amount)
        {
            Title = title;
            Price = price;
            Producer = producer;
            Type = type;
            Amount = amount;
        }

        public Product()
        { }
    }
}
