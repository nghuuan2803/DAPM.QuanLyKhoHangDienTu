namespace WMS.WebAdmin.Model
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Catagory { get; set; }
        public float Quantity { get; set; }

        public ProductDTO(int id, string name, string catagory, float quantity)
        {
            Id = id;
            Name = name;
            Catagory = catagory;
            Quantity = quantity;
        }
    }
}
