using Microsoft.AspNetCore.Mvc;

namespace WebApp_Noite.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Lista()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
