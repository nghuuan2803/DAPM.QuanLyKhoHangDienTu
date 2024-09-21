using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Entities.Organization
{
    public class Partner : BaseEntity<int>
    {
        public string Name { get; set; }
        public string? ContactInfo { get; set; }
    }
}
