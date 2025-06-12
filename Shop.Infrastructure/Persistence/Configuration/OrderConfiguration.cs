using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistence.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(pr => pr.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(p => p.OrderStatus)
            .HasConversion<int>();
    }
}
