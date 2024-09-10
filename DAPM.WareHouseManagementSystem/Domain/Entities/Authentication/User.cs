

using Microsoft.AspNetCore.Identity;

namespace WMS.Domain
{
    public class User : IdentityUser
    {
        public DateTime CreatedOn { get; set; }
    }
}
