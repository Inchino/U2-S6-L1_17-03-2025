using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S6_L1
{
    public class StudenteService
    {
        private readonly AppDbContext _context;

        public StudenteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudenteViewModel>> GetStudentiAsync()
        {
            return await _context.Studenti.Select(s => new StudenteViewModel
            {
                Id = s.Id,
                NomeCompleto = s.Nome + " " + s.Cognome,
                DataDiNascitaFormattata = s.DataDiNascita.ToString("dd/MM/yyyy"),
                Email = s.Email
            }).ToListAsync();
        }
    }

}
