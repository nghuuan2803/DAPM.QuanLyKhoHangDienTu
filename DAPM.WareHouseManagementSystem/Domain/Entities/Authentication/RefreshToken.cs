﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Domain.Entities.Authentication
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Token { get; set; }
    }
}
