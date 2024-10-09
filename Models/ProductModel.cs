namespace DummyJson.Models
{
    public class ProductResponse
    {
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }
    }
}
