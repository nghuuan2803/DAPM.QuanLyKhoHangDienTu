using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Application.DTOs.Requests.Account
{
    public record ChangeUserRoleDTO(string UserMail, string RoleName);
}
