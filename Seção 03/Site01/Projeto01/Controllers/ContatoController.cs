using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Site01.Library.Mail;
using Site01.Models;

namespace Site01.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ReceberContato([FromForm]Contato contato)
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
