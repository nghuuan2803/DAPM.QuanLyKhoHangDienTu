using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Application.DTOs.Requests.Account
{
    public class LocalStorageDTO
    {
        public string? Token { get; set; }
        public string? Refresh { get; set; }
    }
}
