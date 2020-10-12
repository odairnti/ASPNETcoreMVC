using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Library.Filters;
using Site01.Models;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Site01.Controllers
{
    [Login]
    public class PalavraController : Controller
    {
        List<Nivel> niveis = new List<Nivel>();
        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;
            
            niveis.Add(new Nivel() { Id = 1, Nome = "Fácil" });
            niveis.Add(new Nivel() { Id = 2, Nome = "Médio" });
            niveis.Add(new Nivel() { Id = 3, Nome = "Difícil" });

            
        }
        //listar todas as palavras do banco de dados
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;

            var palavras = _db.palavras.ToList();
            var resultadoPaginado = palavras.ToPagedList(pageNumber, 5);


            return View(resultadoPaginado);
        }

        //crud
        [HttpGet]
        public IActionResult Cadastrar()
        {
            ViewBag.Nivel = niveis;
            return View(new Palavra());
        }

        [TempData]
        public string Mensagem { get; set; }

        [HttpPost]
        public IActionResult Cadastrar([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;
            if (ModelState.IsValid)
            {
                _db.palavras.Add(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = $"A palavra {palavra.Descricao} foi cadastrada com sucesso!";

                return RedirectToAction("Index");
            }
            return View(palavra);
        }
        [HttpGet]
        public IActionResult Atualizar(int ID)
        {
            ViewBag.Nivel = niveis;
            Palavra palavra = _db.palavras.Find(ID);
            return View("Cadastrar", palavra);
        }
        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra)
        {
            ViewBag.Nivel = niveis;
            if (ModelState.IsValid)
            {
                _db.palavras.Update(palavra);
                _db.SaveChanges();

                TempData["Mensagem"] = "A palavra '" + palavra.Descricao + "' foi atualizada com sucesso!";

                return RedirectToAction("Index");
            }

            return View("Cadastrar", palavra);
        }

        //{controller}/{action}/38
        //palavra/excluir/38
        //todo - excluir registro do banco
        [HttpGet]
        public IActionResult Excluir(int ID)
        {
            Palavra palavra = _db.palavras.Find(ID);
            _db.palavras.Remove(palavra);
            _db.SaveChanges();

            TempData["MensagemExclusao"] = "A palavra '" + palavra.Descricao + "' foi excluida com sucesso!";
            return RedirectToAction("Index");

        }


    }
}
