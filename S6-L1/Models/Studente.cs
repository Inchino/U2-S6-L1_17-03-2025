using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace S6_L1.Models
{
    public class Studente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cognome { get; set; }

        [Required]
        public DateTime DataDiNascita { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateOnly CreatedAt { get; set; }
    }
}
