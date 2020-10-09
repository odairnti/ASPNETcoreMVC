using Microsoft.AspNetCore.Mvc;
using Site01.Database;
using Site01.Models;
using System.Linq;

namespace Site01.Controllers
{
    public class PalavraController : Controller
    {
        private DatabaseContext _db;
        public PalavraController(DatabaseContext db)
        {
            _db = db;
        }
        //listar todas as palavras do banco de dados
        public IActionResult Index()
        {
            var palavras = _db.palavras.ToList();
            return View(palavras);
        }

        //crud
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View(new Palavra());
        }
        [HttpPost]
        public IActionResult Cadastrar([FromForm] Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                _db.palavras.Add(palavra);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Atualizar(int ID)
        {
            Palavra palavra = _db.palavras.Find(ID);
            return View("Cadastrar", palavra);
        }
        [HttpPost]
        public IActionResult Atualizar([FromForm] Palavra palavra)
        {
            if (ModelState.IsValid)
            {
                _db.palavras.Update(palavra);
                _db.SaveChanges();
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
            _db.palavras.Remove(_db.palavras.Find(ID));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
