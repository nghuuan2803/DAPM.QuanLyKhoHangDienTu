using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class OriginConfig : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(10).IsUnicode(false);
            builder.Property(p => p.Name).HasMaxLength(20);
            string[] ids = { "vn", "cn", "us", "thai", "ger", "uk", "ja", "kor", "rus", "fr" };
            string[] names = { "Việt nam","Trung Quốc", "Mỹ", "Thái Lan", "Đức", "Anh", "Nhật", "Hàn Quốc", "Nga", "Pháp" };
            var data = new List<Origin>();
            for (int i = 0; i < ids.Length; i++)
            {
                data.Add(new Origin { Id = ids[i], Name = names[i] });
            }
            builder.HasData(data);
        }
    }
}
