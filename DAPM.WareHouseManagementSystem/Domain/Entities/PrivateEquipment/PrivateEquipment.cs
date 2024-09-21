using WMS.Domain.Enums;

namespace WMS.Domain.Entities.PrivateEquipment
{
    public class PrivateEquipment: BaseEntity<int>
    {
        public string Name { get; set; }
        public string? Type { get; set; }
        public EquipmentStatus Status { get; set; }
    }
}
