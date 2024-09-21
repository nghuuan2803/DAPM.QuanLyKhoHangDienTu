using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Abstracts
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddMultipleAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null!);
        Task<TEntity> FindAsync(TKey id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
