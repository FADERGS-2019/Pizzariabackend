
// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PizzariaDosGuri.API.Controllers
{
    public class EmailController
    {

        public static async Task Execute(string email,string body,string subject)
        {
            //cria uma mensagem
            MailMessage mail = new MailMessage();

            var autentication = new NetworkCredential("pizzariadosguri@gmail.com", "pizzaria123guri");
            //define os endereços
            mail.From = new MailAddress("williansouza258@gmail.com");
            mail.To.Add(email);

            //define o conteúdo
            mail.Subject = subject;
            mail.Body = body;

            //envia a mensagem
            // SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl=true;
            smtp.Host= "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = autentication;
            smtp.Port = 587;
            


            smtp.Send(mail);
        }
    }
}