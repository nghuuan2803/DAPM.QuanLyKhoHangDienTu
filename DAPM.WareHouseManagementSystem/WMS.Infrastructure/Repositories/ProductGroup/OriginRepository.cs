using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductGroup
{
    public class OriginRepository : BaseRepository<Origin, int>, IOriginRepository
    {
        public OriginRepository(AppDbContext db) : base(db)
        {
        }
    }
}
