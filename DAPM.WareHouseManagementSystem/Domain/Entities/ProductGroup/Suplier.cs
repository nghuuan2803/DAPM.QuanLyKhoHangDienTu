using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Suplier : BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(450)]
        public string? ContactInfo { get; set; }
    }
}
