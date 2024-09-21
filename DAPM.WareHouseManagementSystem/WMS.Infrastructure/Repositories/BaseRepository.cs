using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WMS.Domain.Abstracts;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly AppDbContext _db;
        public BaseRepository(AppDbContext db)
        {
            _db = db;
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task AddMultipleAsync(IEnumerable<TEntity> entities)
        {
            await _db.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual void Update(TEntity entity)
        {

            _db.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _db.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate = null!)
        {
            if (predicate == null)
                return await _db.Set<TEntity>().ToListAsync();
            return await _db.Set<TEntity>().Where(predicate).ToListAsync();
        }
    }
}
