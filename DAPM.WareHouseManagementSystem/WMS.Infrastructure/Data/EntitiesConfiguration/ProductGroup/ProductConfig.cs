using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(50);
            builder.Property(p => p.Photo).HasMaxLength(250).IsUnicode(false);

            // Product -(n)-------(1)- Category || 1 category has many product <-> 1 product has only one category
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId);
            // Product -(n)-------(1)- Brand
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(b => b.BrandId);

            string[] names =
            {
                "Sony Bravia QLED SQ101",
                "Sony Bravia OLED SN101",
                "Sam Sung QLED SSQ113",
                "Sam Sung OLED SS115",
                "Điều hòa Panasonic siêu mát lạnh",
                "Máy lạnh Tosiba buốt giá con tim",
                "Tủ lạnh LG GG",
                "Máy giặt AQUA ảo quá",
            };
            double[] prices = { 10000000, 15000000, 12000000, 9000000, 6000000, 5000000, 7000000, 8000000 };
            var data = new List<Product>();
            for (int i = 1; i <= names.Length; i++)
            {
                data.Add(new Product {Id=i, Name = names[i-1], Price = prices[i-1], CreatedOn = DateTime.Now });
            }
            builder.HasData(data);
        }
    }
}
