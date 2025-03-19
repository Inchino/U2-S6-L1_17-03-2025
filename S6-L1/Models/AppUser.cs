using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace S6_L1.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required DateOnly BirthDate { get; set; }

        public ICollection<AppUserRole> AppUserRole { get; set; }
    }
}
