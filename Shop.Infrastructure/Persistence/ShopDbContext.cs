using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistence
{
    internal class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(op => op.Products)
                .WithOne(op => op.Category)
                .HasForeignKey(op=>op.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .OwnsOne(p => p.Address);

            modelBuilder.Entity<Customer>()
                .HasMany(p => p.Orders)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
               .Property(p => p.UnitPrice)
               .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
               .OwnsOne(p => p.ShippingAddress);

            modelBuilder.Entity<Order>()
                .Property(pr =>pr.CreatedAt).HasDefaultValueSql("GETUTCDATE()");

            modelBuilder.Entity<Order>()
              .Property(p => p.OrderStatus)
              .HasConversion<int>();

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Orders)
                .UsingEntity<OrderItem>(
                    j => j
                        .HasOne(pt => pt.Product)
                        .WithMany(t => t.OrderItems)
                        .HasForeignKey(pt => pt.ProductId),
                    j => j
                        .HasOne(pt => pt.Order)
                        .WithMany(p => p.OrderItems)
                        .HasForeignKey(pt => pt.OrderId),
                    j =>
                    {                        
                        j.HasKey(t => new { t.ProductId, t.OrderId });
                    });
        }
    }
}
