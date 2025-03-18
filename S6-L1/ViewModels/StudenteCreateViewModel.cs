using System.ComponentModel.DataAnnotations;

namespace S6_L1.ViewModels
{
    public class StudenteCreateViewModel
    {
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
    }
}
