using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace S6_L1.Models
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        [ForeignKey("RoleId")]
        public AppRole Role { get; set; }
    }
}
