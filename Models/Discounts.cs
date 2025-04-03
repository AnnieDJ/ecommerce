namespace ecommerce.Models
{
    public class Discounts
    {
        public Guid Id { get; set; }
        public Guid? MerchantId { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
