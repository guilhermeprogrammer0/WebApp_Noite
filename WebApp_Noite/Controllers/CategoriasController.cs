﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Lista()
        {
            return View(db.Categorias.ToList());
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
