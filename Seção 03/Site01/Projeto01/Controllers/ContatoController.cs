using Microsoft.AspNetCore.Mvc;
using Site01.Library.Filters;
using Site01.Library.Mail;
using Site01.Models;

namespace Site01.Controllers
{
    [Login]
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReceberContato([FromForm] Contato contato)
        {
            if (ModelState.IsValid)
            {
                EnviarEmail.EnviarMensagemContato(contato);
                ViewBag.Mensagem = "Mensagem Enviada com Sucesso!";
                return View("Index");
            }
            else
            {
                return View("Index");
            }
        }


    }
}
