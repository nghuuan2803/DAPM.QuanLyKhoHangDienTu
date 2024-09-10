using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Application.DTOs.Requests.Account
{
    public class LoginDTO
    {
        [EmailAddress, Required, DataType(DataType.EmailAddress)]
        [RegularExpression("[^@ \\t\\r\\n]+@[^@ \\t\\r\\n]+\\.[^@ \\t\\r\\n]+", ErrorMessage ="Email không hợp lệ! Email phải có dạng ...@gmail, @hotmail,...")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
