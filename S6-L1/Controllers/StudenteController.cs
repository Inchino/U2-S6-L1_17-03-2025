using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S6_L1.Services;
using S6_L1.ViewModels;
using System.Threading.Tasks;

namespace S6_L1.Controllers
{
    public class StudenteController : Controller
    {
        private readonly StudenteService _studenteService;
        private readonly LoggerService _loggerService;

        public StudenteController(StudenteService studenteService, LoggerService loggerService)
        {
            this._studenteService = studenteService;
            this._loggerService = loggerService;
        }

        public IActionResult Index()
        {
            return View(); //1
        }

        [Authorize]
        [HttpGet("studente/get-all")]
        public async Task<IActionResult> ListaStudenti()
        {
            var studentiList = await _studenteService.GetAllStudentiAsync();
            return PartialView("_StudenteList", studentiList); //2
        }

        public IActionResult Crea()
        {
            return PartialView("_AddForm"); //3
        }

        [HttpPost]
        public async Task<IActionResult> Crea(StudenteCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Errore durante il salvataggio" });
            }

            var result = await _studenteService.AddStudenteAsync(model);
            if (!result)
            {
                return Json(new { success = false, message = "Errore durante il salvataggio" });
            }

            _loggerService.LogInformation("Studente aggiunto con successo");
            return Json(new { success = true, message = "Studente aggiunto con successo" });
        }

        [Authorize]
        [HttpGet("studente/dettaglio/{id:int}")]
        public async Task<IActionResult> Dettaglio(int id)
        {
            var studente = await _studenteService.GetStudenteDetailByIdAsync(id);
            if (studente == null)
            {
                return Json(new { success = false, message = "Nessuno studente trovato" });
            }
            return Json(new { success = true, data = studente });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Elimina(int id)
        {
            var result = await _studenteService.DeleteStudenteByIdAsync(id);
            if (!result)
            {
                return Json(new { success = false, message = "Errore durante l'eliminazione" });
            }

            _loggerService.LogInformation("Studente eliminato con successo");
            return Json(new { success = true, message = "Studente eliminato con successo" });
        }

        public async Task<IActionResult> Modifica(int id)
        {
            var studente = await _studenteService.GetStudenteDetailByIdAsync(id);
            if (studente == null)
            {
                return RedirectToAction("Index");
            }

            var editModel = new StudenteEditViewModel()
            {
                Id = studente.Id,
                Nome = studente.NomeCompleto.Split(' ')[0],
                Cognome = studente.NomeCompleto.Split(' ')[1],
                DataDiNascita = DateTime.Parse(studente.DataDiNascitaFormattata),
                Email = studente.Email
            };

            return PartialView("_EditForm", editModel); //4
        }

        [HttpPost("studente/modifica/salva")]
        public async Task<IActionResult> Modifica(StudenteEditViewModel model)
        {
            var result = await _studenteService.UpdateStudenteAsync(model);
            if (!result)
            {
                return Json(new { success = false, message = "Errore durante l'aggiornamento" });
            }

            _loggerService.LogInformation("Studente aggiornato con successo");
            return Json(new { success = true, message = "Studente aggiornato con successo" });
        }
    }
}
