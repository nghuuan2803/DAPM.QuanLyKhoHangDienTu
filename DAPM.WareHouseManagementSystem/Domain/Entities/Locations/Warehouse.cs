using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Locations
{
    public class Warehouse : BaseEntity<string>
    {
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        public double Acreage { get; set; }
        public bool Discontinued { get; set; }
        public CapacityStatus Status { get; set; }
    }
}
