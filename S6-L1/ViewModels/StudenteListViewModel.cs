using System.ComponentModel.DataAnnotations;

namespace S6_L1.ViewModels
{
    public class StudenteListViewModel
    {
        [Required]
        public List<StudenteViewModel> Studenti { get; set; } = new List<StudenteViewModel>();
    }
}
