using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace S6_L1.Controllers
{
    [Authorize(Roles = "Docente")]
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
