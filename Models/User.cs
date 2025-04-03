namespace ecommerce.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string? ActivationToken { get; set; }
        public DateTime? ActivationExpires { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}