using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class CategoryRepository : BaseRepository<Category,int>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext db) : base(db) { }
    }
}
