using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Entities.Organization;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class SuplierConfig : IEntityTypeConfiguration<Suplier>
    {
        public void Configure(EntityTypeBuilder<Suplier> builder)
        {
            string[] names =
            {
                "Cty TNHH ABC",
                "Cty TNHH XYZ",
                "Cty CP Đông Tây",
                "Cty CP Nam Bắc",
                "Tập Đoàn Đa Cấp Xuyên Quốc Gia Cơ Hội",
                "Nhà Phân Phối Chính Hãng Xiaomi",
                "Nhà Phân Phối Chính Hãng Cây Sung",
            };
            var data = new List<Suplier>();
            for (int i = 1; i <= names.Length; i++)
            {
                data.Add(new Suplier { Id = i, Name = names[i - 1] });
            }
            builder.HasData(data);
        }
    }
}
