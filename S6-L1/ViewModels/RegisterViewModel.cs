using System;
using System.ComponentModel.DataAnnotations;

namespace S6_L1.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Conferma la password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le password non corrispondono")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public string Role { get; set; } = "Studente";
    }
}
