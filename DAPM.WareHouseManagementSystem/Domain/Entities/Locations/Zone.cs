using WMS.Domain.Enums;

namespace WMS.Domain.Entities.Locations
{
    public class Zone : BaseEntity<int>
    {
        public string Name { get; set; }
        public CapacityStatus Status { get; set; }
        public bool Discontinued { get; set; }
    }
}
