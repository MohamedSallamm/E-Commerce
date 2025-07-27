using E_Com.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Com.infrastructure.Data.Configuration
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasData(new Photo { Id = 1, ImageName = "Test", ProductId = 1 });
        }
    }
}
