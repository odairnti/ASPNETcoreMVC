using Microsoft.AspNetCore.Mvc;
using Site01.Models;

namespace Site01.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login([FromForm] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.Email == "odair.nti@gmail.com" && usuario.Senha == "123456")
                {
                    return RedirectToAction("index", "palavra");
                }
                else
                {
                    ViewBag.Mensagem = "Os dados informados são inválidos.";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}
