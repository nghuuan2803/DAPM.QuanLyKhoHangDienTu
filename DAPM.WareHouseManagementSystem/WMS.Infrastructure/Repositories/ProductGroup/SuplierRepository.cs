using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Domain.Entities.ProductInfo;
using WMS.Infrastructure.Data;

namespace WMS.Infrastructure.Repositories.ProductData
{
    public class SuplierRepository : BaseRepository<Suplier, int>, ISuplierRepository
    {
        public SuplierRepository(AppDbContext db) : base(db)
        {
        }
    }
}
