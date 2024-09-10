using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Application.DTOs.Responses.Account
{
    public record UserClaimsDTO (string FullName = null!, string UserName = null!, string Email = null!, string Role = null!);
}
