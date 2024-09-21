using WMS.Domain.Entities.Locations;

namespace WMS.Domain.Entities.Organization
{
    public class Employee : BaseEntity<string>
    {
        public double Salary { get; set; }
        public string FullName { get; set; }
        public DateOnly BirthDate { get; set; }
        public string MainRole { get; set; }
        public int? WareHouseId { get; set; }

        public Warehouse? Warehouse { get; set; }
    }
}
