namespace ecommerce.Models
{
    public class Products
    {
        public Guid Id { get; set; }
        public Guid MerchantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Guid? DiscountId { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
