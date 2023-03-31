using Microsoft.AspNetCore.Mvc;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Listar()
        {
            return View();
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
