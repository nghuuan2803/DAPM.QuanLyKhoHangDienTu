using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class ProductRepository : BaseRepository<Product, int>, IProductRepository
    {
        public ProductRepository(AppDbContext db) : base(db)
        {
        }
    }
}
