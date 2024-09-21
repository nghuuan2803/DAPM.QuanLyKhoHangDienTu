using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class BatchRepository : BaseRepository<Batch, string>, IBatchRepository
    {
        public BatchRepository(AppDbContext db) : base(db)
        {
        }
    }
}
