using E_Com.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Com.infrastructure.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(propertyExpression: x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(propertyExpression: x => x.Id).IsRequired();
            builder.HasData(new Category { Id = 1, Name = "Test", Description = "Test" });
        }
    }
}
