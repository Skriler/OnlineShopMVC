namespace OnlineShopMVC.Models
{
    public class Order
    {
        public int Id { get; private set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Order(string username, string address, string contactPhone, int productId)
        {
            Username = username;
            Address = address;
            ContactPhone = contactPhone;
            ProductId = productId;
        }

        public Order()
        { }
    }
}
