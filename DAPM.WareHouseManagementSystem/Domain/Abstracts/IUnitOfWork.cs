using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Abstracts.ProductRepo;

namespace WMS.Domain.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository CategoryRepository { get; set; }
        IBrandRepository BrandRepository { get; set; }
        IBatchRepository BatchRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IOriginRepository OriginRepository { get; set; }

        Task BeginAsync();
        Task SaveAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
