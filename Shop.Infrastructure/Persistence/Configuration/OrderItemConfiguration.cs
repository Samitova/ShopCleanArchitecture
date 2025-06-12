using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistence.Configuration;
internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(bc => new { bc.ProductId, bc.OrderId });

        builder
            .Property(p => p.UnitPrice)
            .HasColumnType("decimal(18,2)");

        builder
            .HasOne(bc => bc.Order)
            .WithMany(b => b.OrderItems)
            .HasForeignKey(bc => bc.OrderId);

        builder
            .HasOne(bc => bc.Product)
            .WithMany(c => c.OrderItems)
            .HasForeignKey(bc => bc.ProductId);
    }
}
