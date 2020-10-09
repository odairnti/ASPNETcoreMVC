using Site01.Models;
using System.Net;
using System.Net.Mail;

namespace Site01.Library.Mail
{
    public class EnviarEmail
    {
        public static async void EnviarMensagemContato(Contato contato)
        {
            string vConteudo = string.Format("Nome: {0}<br />E-mail: {1}<br />Assunto: {2}<br />Mensagem:{3}", contato.Nome, contato.Email, contato.Assunto, contato.Mensagem);


            SmtpClient smtp = new SmtpClient(Constants.ServidosSMTP, Constants.PortaSMTP);

            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = Constants.ServidosSMTP;
            smtp.Port = Constants.PortaSMTP;
            smtp.Credentials = new NetworkCredential(Constants.Usuario, Constants.Senha);

            //mensagem de email
            MailMessage mensagem = new MailMessage();
            mensagem.To.Add("odair.nti@gmail.com");
            mensagem.From = new MailAddress("odair.nti@gmail.com");
            mensagem.Subject = "Formulário para Contato";

            mensagem.IsBodyHtml = true;
            mensagem.Body = "<h1>Formulário para Contato </h1>" + vConteudo;

            smtp.Timeout = 20_000;
            await smtp.SendMailAsync(mensagem);

        }
    }
}
