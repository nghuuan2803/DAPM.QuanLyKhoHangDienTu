using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Locations
{
    public class Shelf : BaseEntity<int>
    {
        public int Name { get; set; }
        public int CompartmentQty { get; set; } = 10;
        public CapacityStatus Status { get; set; }
        public bool Discontinued { get; set; }
    }
}
