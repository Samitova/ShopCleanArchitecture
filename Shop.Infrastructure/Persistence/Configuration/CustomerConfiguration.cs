using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistence.Configuration;
internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(b => b.Address)
            .IsRequired();

        builder.Property(b => b.Email)
            .IsRequired();

        builder.Property(b => b.Phone)
            .IsRequired();

        builder.HasMany(p => p.Orders)
            .WithOne(p => p.Customer)
            .HasForeignKey(p => p.CustomerId);
    }
}
