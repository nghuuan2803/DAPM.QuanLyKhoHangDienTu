using WMS.Domain.Entities.Organization;
using WMS.Domain.Enums;

namespace WMS.Domain.Entities.ProductInfo
{
    public class Batch :BaseEntity<string>
    {
        public int ProductId { get; set; }
        public int SuplierId { get; set; }
        public int? Owner { get; set; }
        public string OriginId { get; set; }
        public int ErrorItemCount { get; set; }
        public DateOnly ManufactureDate { get; set; } //NSX
        public BatchStatus Status { get; set; }

        public Suplier? Suplier { get; set; }
        public Product? Product { get; set; }
        public Partner? Partner { get; set; }
        public Origin? Origin { get; set; }
    }
}
