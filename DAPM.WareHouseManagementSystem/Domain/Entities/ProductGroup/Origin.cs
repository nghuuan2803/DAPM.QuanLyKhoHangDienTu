using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities.ProductInfo
{
    //Xuất sứ sản phẩm
    public class Origin
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
