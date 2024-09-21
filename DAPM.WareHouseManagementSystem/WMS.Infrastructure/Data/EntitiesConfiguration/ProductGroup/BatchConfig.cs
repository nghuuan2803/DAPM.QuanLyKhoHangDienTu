using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Infrastructure.Data.EntitiesConfiguration.ProductGroup
{
    public class BatchConfig : IEntityTypeConfiguration<Batch>
    {
        public void Configure(EntityTypeBuilder<Batch> builder)
        {
            builder.Property(p => p.Id).HasMaxLength(12);
            builder.Property(p => p.OriginId).HasMaxLength(10).IsUnicode(false);

            builder.HasOne(p => p.Suplier).WithMany().HasForeignKey(p => p.SuplierId);
            builder.HasOne(p => p.Product).WithMany().HasForeignKey(p => p.ProductId);
            builder.HasOne(p => p.Origin).WithMany().HasForeignKey(p => p.OriginId);
            builder.HasOne(p => p.Partner).WithMany().HasForeignKey(p => p.Owner);
        }
    }
}
