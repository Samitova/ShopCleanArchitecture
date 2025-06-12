using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistence.Configuration;
public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
           .HasMaxLength(100)
           .IsRequired();

        builder.Property(b => b.Description)
            .IsRequired();

        builder.HasMany(op => op.Products)
            .WithOne(op => op.Category)
            .HasForeignKey(op => op.CategoryId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    }
}
