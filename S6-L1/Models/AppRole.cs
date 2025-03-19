using Microsoft.AspNetCore.Identity;

namespace S6_L1.Models
{
    public class AppRole : IdentityRole
    {
        public ICollection<AppUserRole> AppUserRole { get; set; }
    }
}
