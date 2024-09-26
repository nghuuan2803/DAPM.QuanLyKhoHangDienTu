namespace WMS.WebAdmin.Model
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInf { get; set; }

        public LocationDTO(int id, string name, string contactInf)
        {
            Id = id;
            Name = name;
            ContactInf = contactInf;
        }
    }
}
