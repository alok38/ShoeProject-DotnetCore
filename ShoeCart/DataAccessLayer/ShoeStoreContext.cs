using Microsoft.EntityFrameworkCore;
using ShoeCart.Models;

namespace ShoeCart.DataAccessLayer
{
    public class ShoeStoreContext : DbContext
    {
        public ShoeStoreContext(DbContextOptions<ShoeStoreContext> options) : base(options)
        {

        }
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Review> Reviews { get; set; }


    }
}
