using Microsoft.AspNetCore.Mvc;

namespace WebApp_Noite.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
