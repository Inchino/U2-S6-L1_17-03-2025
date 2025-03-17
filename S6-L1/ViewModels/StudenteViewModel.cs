using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S6_L1
{
    public class StudenteViewModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string DataDiNascitaFormattata { get; set; }
        public string Email { get; set; }
    }
}
