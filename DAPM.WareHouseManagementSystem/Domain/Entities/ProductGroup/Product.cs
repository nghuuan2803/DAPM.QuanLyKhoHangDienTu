using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string? Photo { get; set; }
        public bool Discontinued { get; set; }

        public Category? Category { get; set; }
        public Brand? Brand { get; set; }
    }
}
