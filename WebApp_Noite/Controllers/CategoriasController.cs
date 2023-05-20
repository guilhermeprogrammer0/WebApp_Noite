using Microsoft.AspNetCore.Mvc;
using WebApp_Noite.Tabelas;

namespace WebApp_Noite.Controllers
{
    public class CategoriasController : Controller
    {
        private Contexto db;
        public CategoriasController(Contexto contexto)
        {
            db = contexto;
        }
        public IActionResult Cadastro()
        {
            return View(new Categorias());
        }

        public IActionResult Lista(string Busca)
        {
            if (string.IsNullOrEmpty(Busca))
            {
                return View(db.Categorias.ToList());
            }
            else
            {
                List<Categorias> dados = new List<Categorias>();
                dados = db.Categorias.Where(a => a.Nome.Contains(Busca)).ToList();
                return View(dados);
            }
        }
        [HttpPost]
        public IActionResult SalvarDados(Categorias dados)
        {
            db.Categorias.Add(dados);
            db.SaveChanges();
            return RedirectToAction("Lista");
        }
        

        
    }
}
