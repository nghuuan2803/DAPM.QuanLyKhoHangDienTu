namespace WMS.WebAdmin.Model
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Noidung { get; set; }

        public EmployeeDTO(int id, string name, string email, string noidung)
        {
            Id = id;
            Name = name;
            Email = email;
            Noidung = noidung;
        }
    }
}
