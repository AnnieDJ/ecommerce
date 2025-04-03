namespace ecommerce.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<User> ListUsers { get; set; }  // ✅ 确保这里是 `User`
        public User Users { get; set; }  // ✅ 确保这里是 `User`
        public List<Merchants> ListMerchants { get; set; }
        public Merchants Merchant { get; set; }
        public List<Products> ListProducts { get; set; }
        public Products Product { get; set; }
        public List<Orders> ListOrders { get; set; }
        public Orders Order { get; set; }
        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems OrderItem { get; set; }
    }
}
