using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
