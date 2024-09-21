using System.Linq.Expressions;
using WMS.Application.DTOs.Responses;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Application.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<BaseResponse> AddAsync(Category model);
        Task<BaseResponse> AddMultipleAsync(IEnumerable<Category> models);
        Task<BaseResponse> UpdateAsync(Category model);
        Task<BaseResponse> DeleteAsync(int id);

        Task<BaseResponse> FindAsync(int id);
        Task<BaseResponse> GetListAsync(Expression<Func<Category, bool>> predicate = null!);
    }
}
