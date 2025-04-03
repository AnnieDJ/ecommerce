using Microsoft.EntityFrameworkCore;
using ecommerce.Models;

namespace ecommerce.Data
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}