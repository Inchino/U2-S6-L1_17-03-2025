using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using S6_L1;

namespace S6_L1
{
    public class StudenteController : Controller
{
    private readonly StudenteService _studenteService;

    public StudenteController(StudenteService studenteService)
    {
        _studenteService = studenteService;
    }

    public async Task<IActionResult> Index()
    {
        var studenti = await _studenteService.GetStudentiAsync();
        return View(studenti);
    }

    public async Task<IActionResult> ListaStudenti()
    {
        var studenti = await _studenteService.GetStudentiAsync();
        return PartialView("_ListaStudenti", studenti);
    }

    public async Task<IActionResult> Dettaglio(int id)
    {
        var studente = await _studenteService.GetStudenteByIdAsync(id);
        if (studente == null)
        {
            return NotFound();
        }
        return PartialView("_DettaglioStudente", studente);
    }
}
}
