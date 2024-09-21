using Microsoft.EntityFrameworkCore.Storage;
using WMS.Domain.Abstracts;
using WMS.Domain.Abstracts.ProductGroup;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Infrastructure.Data;
using WMS.Infrastructure.Repositories.ProductData;
using WMS.Infrastructure.Repositories.ProductGroup;

namespace WMS.Infrastructure.SqlsvUnitOfwork
{
    public class UnitOfWork(AppDbContext _db) : IUnitOfWork
    {
        private IDbContextTransaction _transaction = null!;

        public IProductRepository ProductRepository { get; set; } = new ProductRepository(_db);
        public ICategoryRepository CategoryRepository { get; set; } = new CategoryRepository(_db);
        public IBrandRepository BrandRepository { get; set; } = new BrandRepository(_db);
        public IBatchRepository BatchRepository { get; set; } = new BatchRepository(_db);
        public IOriginRepository OriginRepository { get; set; } = new OriginRepository(_db);

        public async Task BeginAsync()
        {
            _transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _db.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            DisposeTransaction();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        private void DisposeTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null!;
            }
        }
        public void Dispose()
        {
            DisposeTransaction();
            _db.Dispose();
        }
    }
}
