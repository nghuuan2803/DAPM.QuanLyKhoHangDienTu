using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Abstracts.ProductRepo;
using WMS.Infrastructure.Repositories.ProductData;

namespace WMS.Infrastructure.DependencyInjection
{
    public static class ThanhTrungDI
    {
        public static void ThanhTrungAddID(this IServiceCollection services)
        {
            services.AddScoped<IBrandRepository, BrandRepository>();
        }
    }
}
