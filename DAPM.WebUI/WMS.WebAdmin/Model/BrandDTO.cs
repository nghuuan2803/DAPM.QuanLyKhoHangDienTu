namespace WMS.WebAdmin.Model
{
    public class BrandDTO
    {
        public BrandDTO(int id, string name, string contactInfo)
        {
            this.id = id;
            this.name = name;
            ContactInfo = contactInfo;
        }

        public int id  {  get; set; }
        public string name { get; set; }
        public string ContactInfo { get; set; }
    }
}
