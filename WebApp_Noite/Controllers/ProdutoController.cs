using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApp_Noite.Models;
using WebApp_Noite.Tabelas;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public static List<ProdutosModel> db_produtos = new List<ProdutosModel>();
        private Contexto db;

        public ProdutoController(Contexto contexto) { 
        
            db = contexto;
        }
        public IActionResult Lista(String filtro, string busca)
        {
            if (string.IsNullOrEmpty(busca))
            {
                return View(db_produtos);
            }
            else
            {
                switch (filtro)
                {     
                    case "id":
                        return View(db_produtos.Where(a => a.Id.ToString() == busca).ToList());
                    break;
                    case "nome":
                        return View(db_produtos.Where(a => a.Nome.Contains(busca)).ToList());
                        break;
                    case "qtd":
                        return View(db_produtos.Where(a => a.QtdEstoque.ToString() == busca).ToList());
                        break;
                    default:
                        return View(
                            db_produtos.Where(a => a.Id.ToString() == busca || a.Nome.Contains(busca) || a.QtdEstoque.ToString() == busca).ToList());
                    break;

                }
            }
        }
        public IActionResult Cadastrar()
        {
            ProdutosModel model = new ProdutosModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SalvarProdutos(ProdutosModel produto)
        {
            if(produto.Id == 0)
            {
                Random rand= new Random();
                produto.Id = rand.Next(1, 9999);
                db_produtos.Add(produto);
            }
            else
            {
                int indice = db_produtos.FindIndex(a => a.Id == produto.Id);
                db_produtos[indice] = produto;
            }
           return RedirectToAction("Lista");

        }

        public IActionResult Excluir(int id)
        {
            ProdutosModel item = db_produtos.Find(a => a.Id == id);
            if(item != null)
            {
                db_produtos.Remove(item);
            }
            return RedirectToAction("Lista");
        }
        public IActionResult Editar(int id)
        {
            ProdutosModel item = db_produtos.Find(a => a.Id == id);
            if(item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
       
    }
}
