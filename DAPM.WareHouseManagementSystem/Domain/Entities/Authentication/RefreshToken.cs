using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.Authentication
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
