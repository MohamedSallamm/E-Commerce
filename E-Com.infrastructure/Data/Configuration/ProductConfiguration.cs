﻿using E_Com.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Com.infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(propertyExpression: x => x.Name).IsRequired();
            builder.Property(propertyExpression: x => x.Description).IsRequired();
            builder.Property(propertyExpression: x => x.NewPrice).HasColumnType(typeName: "decimal(18.2)");
            builder.HasData(new Product { Id = 1, Name = "Test", Description = "Test", CategoryId = 1, NewPrice = 100 });
        }
    }
}
