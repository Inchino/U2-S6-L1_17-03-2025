using Microsoft.EntityFrameworkCore;
using S6_L1.Data;
using S6_L1.Models;
using S6_L1.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;


namespace S6_L1.Services
{
    public class StudenteService
    {
        private readonly AppDbContext _context;
        private readonly LoggerService _loggerService;

        public StudenteService(AppDbContext context, LoggerService loggerService)
        {
            this._context = context;
            this._loggerService = loggerService;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return false;
            }
        }


        public async Task<StudenteListViewModel> GetAllStudentiAsync()
        {
            var studentiList = new StudenteListViewModel();
            try
            {
                studentiList.Studenti = await _context.Studenti.Select(s => new StudenteViewModel
                {
                    Id = s.Id,
                    NomeCompleto = s.Nome + " " + s.Cognome,
                    DataDiNascitaFormattata = s.DataDiNascita.ToString("dd/MM/yyyy"),
                    Email = s.Email
                }).ToListAsync();
                _loggerService.LogInformation("Lista studenti richiesta dall'amministratore");
            }
            catch (Exception ex)
            {
                studentiList.Studenti = null;
                _loggerService.LogError(ex.Message);
            }
            return studentiList;
        }

        public async Task<bool> AddStudenteAsync(StudenteCreateViewModel studenteViewModel)
        {
            try
            {
                var studente = new Studente
                {
                    Nome = studenteViewModel.Nome,
                    Cognome = studenteViewModel.Cognome,
                    DataDiNascita = studenteViewModel.DataDiNascita,
                    Email = studenteViewModel.Email
                };

                _context.Studenti.Add(studente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return false;
            }
        }

        public async Task<StudenteDetailViewModel?> GetStudenteDetailByIdAsync(int id)
        {
            try
            {
                return await _context.Studenti
                     .Where(s => s.Id == id)
                     .Select(s => new StudenteDetailViewModel
                     {
                         Id = s.Id,
                         NomeCompleto = s.Nome + " " + s.Cognome,
                         DataDiNascita = s.DataDiNascita,
                         Email = s.Email
    })
    .FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeleteStudenteByIdAsync(int id)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(id);
                if (studente == null)
                {
                    _loggerService.LogWarning("Studente non trovato");
                    return false;
                }
                _context.Studenti.Remove(studente);
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateStudenteAsync(StudenteEditViewModel studenteViewModel)
        {
            try
            {
                var studente = await _context.Studenti.FindAsync(studenteViewModel.Id);
                if (studente == null)
                {
                    return false;
                }
                studente.Nome = studenteViewModel.Nome;
                studente.Cognome = studenteViewModel.Cognome;
                studente.DataDiNascita = studenteViewModel.DataDiNascita;
                studente.Email = studenteViewModel.Email;
                return await SaveAsync();
            }
            catch (Exception ex)
            {
                _loggerService.LogError(ex.Message);
                return false;
            }
        }
    }
}

