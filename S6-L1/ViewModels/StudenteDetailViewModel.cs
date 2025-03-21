namespace S6_L1.ViewModels
{
    public class StudenteDetailViewModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }

        public DateTime? DataDiNascita { get; set; }

        public string DataDiNascitaFormattata => DataDiNascita.HasValue ? DataDiNascita.Value.ToString("dd/MM/yyyy") : "N/A";

        public string Email { get; set; }
    }
}
