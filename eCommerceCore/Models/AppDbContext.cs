using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerceCore.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserCredential> UserCredential { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductVariation> ProductVariations { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<OrderRecord> OrderRecord { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
