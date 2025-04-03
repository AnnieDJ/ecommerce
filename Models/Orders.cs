namespace ecommerce.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MerchantId { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalPrice { get; set; }
        public string ProductNames { get; set; }
        public string Status { get; set; }
        public string PaymentId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
