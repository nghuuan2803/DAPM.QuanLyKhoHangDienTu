﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.Domain.Abstracts.ProductRepo
{
    public interface ICategoryRepository : IBaseRepository<Category, int>
    {
    }
}
