using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(100);
            string[] names = { "Sony", "Panasonic", "Sam Sung", "Apple", " Xiaomi", "Tosiba", "Aqua", "Senko" };
            var data = new List<Brand>();
            for (int i = 1; i <= names.Length; i++)
            {
                data.Add(new Brand { Id = i, Name = names[i-1] });
            }
            builder.HasData(data);
        }
    }
}
