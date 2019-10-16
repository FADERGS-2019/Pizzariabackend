
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
    public class ExampleController
    {

        public static async Task Execute(string email,string body)
        {
            //cria uma mensagem
            MailMessage mail = new MailMessage();

            var autentication = new NetworkCredential("pizzariadosguri@gmail.com", "pizzaria123guri");
            //define os endereços
            mail.From = new MailAddress("williansouza258@gmail.com");
            mail.To.Add("willian_santos185@hotmail.com");

            //define o conteúdo
            mail.Subject = "Este é um simples ,muito simples email";
            mail.Body = "Este é o corpo do email";

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